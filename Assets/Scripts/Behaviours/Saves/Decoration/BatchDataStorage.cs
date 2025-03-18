using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;
using Cysharp.Threading.Tasks;

namespace Behaviours
{
    abstract class BatchDataStorage : IDataStorage
    {
        protected const string LogTag = nameof(BatchDataStorage);
        protected static readonly ILogger Logger = Debug.unityLogger;

        [NotNull] private readonly IDataStorage _hotStorage;
        [NotNull] private readonly IDataStorage _coldStorage;

        [NotNull] private readonly Batch _batch = new();


        protected BatchDataStorage([NotNull] IDataStorage hotStorage, [NotNull] IDataStorage coldStorage)
        {
            _hotStorage = hotStorage ?? throw new ArgumentNullException(nameof(hotStorage));
            _coldStorage = coldStorage ?? throw new ArgumentNullException(nameof(coldStorage));
        }

        public void Dispose()
        {
            _batch.Clear();
            _hotStorage.Dispose();
            _coldStorage.Dispose();
            OnDisposed();
        }


        public async UniTask InitializeAsync([NotNull, ItemNotNull] IReadOnlyCollection<string> allKeys)
        {
            if (allKeys == null)
                throw new ArgumentNullException(nameof(allKeys));

            Logger.Log(LogTag, "Reading from cold storage...");
            IEnumerable<KeyValuePair<string,string>> serializedData =
                await _coldStorage.ReadAsync(allKeys);

            Logger.Log(LogTag, "Writing to hot storage...");
            await _hotStorage.WriteAsync(serializedData.ToArray());

            Logger.Log(LogTag, "Initialized");
        }

        public UniTask<bool> ExistsAsync(string key) =>
            _hotStorage.ExistsAsync(key);


        public UniTask<IEnumerable<KeyValuePair<string, string>>> ReadAsync(IReadOnlyCollection<string> keys) =>
            _hotStorage.ReadAsync(keys);

        public UniTask<string> ReadAsync(string key) =>
            _hotStorage.ReadAsync(key);


        public UniTask WriteAsync(IReadOnlyCollection<KeyValuePair<string, string>> serializedData) =>
            _hotStorage.WriteAsync(serializedData).ContinueWith(() =>
            {
                _batch.CollectWriteDiffs(serializedData);
                OnBatchUpdated();
            });

        public UniTask WriteAsync(string key, string serializedData) =>
            _hotStorage.WriteAsync(key, serializedData).ContinueWith(() =>
            {
                _batch.CollectWriteDiff(key, serializedData);
                OnBatchUpdated();
            });


        public UniTask DeleteAsync(IReadOnlyCollection<string> keys) =>
            _hotStorage.DeleteAsync(keys).ContinueWith(() =>
            {
                _batch.CollectDeleteDiffs(keys);
                OnBatchUpdated();
            });

        public UniTask DeleteAsync(string key) =>
            _hotStorage.DeleteAsync(key).ContinueWith(() =>
            {
                _batch.CollectDeleteDiff(key);
                OnBatchUpdated();
            });


        protected async UniTask CommitBatchAsync()
        {
            Logger.Log(LogTag, "Commiting write diffs...");
            foreach ((string key, string serializedData) in _batch.WriteDiffs)
                await _coldStorage.WriteAsync(key, serializedData);

            Logger.Log(LogTag, "Commiting delete diffs...");
            foreach (string key in _batch.DeleteDiffs)
                await _coldStorage.DeleteAsync(key);

            _batch.Clear();
            Logger.Log(LogTag, "Commited batch");
        }

        protected abstract void OnBatchUpdated();
        protected virtual void OnDisposed() { }
    }
}