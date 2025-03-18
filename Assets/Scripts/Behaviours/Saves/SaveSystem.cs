using System;
using System.Linq;
using UnityEngine;
using JetBrains.Annotations;
using Cysharp.Threading.Tasks;

namespace Behaviours
{
    sealed class SaveSystem : ISaveSystem
    {
        private const string LogTag = nameof(SaveSystem);
        private static readonly ILogger Logger = Debug.unityLogger;

        [NotNull] private readonly ISerializer _serializer;
        [NotNull] private readonly IDataStorage _dataStorage;
        [NotNull] private readonly IKeysProvider _keysRepository;
        [NotNull] private readonly ITimestampProvider _timeStampProvider;

        public SaveSystem([NotNull] ISerializer serializer, [NotNull] IDataStorage dataStorage,
            [NotNull] IKeysProvider keysRepository, [NotNull] ITimestampProvider timeStampProvider)
        {
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _dataStorage = dataStorage ?? throw new ArgumentNullException(nameof(dataStorage));
            _keysRepository = keysRepository ?? throw new ArgumentNullException(nameof(keysRepository));
            _timeStampProvider = timeStampProvider ?? throw new ArgumentNullException(nameof(timeStampProvider));
        }

        public async UniTask InitializeAsync()
        {
            Logger.Log(LogTag, "Initializing ...");

            if (_dataStorage is BatchDataStorage batchDataStorage)
            {
                string[] allKeys = _keysRepository.ProvideAll().ToArray();
                await batchDataStorage.InitializeAsync(allKeys);
            }

            Logger.Log(LogTag, "Initialized");
        }

        public async UniTask SaveAsync<TData>(TData data) where TData : ISaveData
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            string dataType = typeof(TData).Name;
            Logger.Log(LogTag, $"Saving data of type \"{dataType}\"...");

            data.Timestamp = _timeStampProvider.Provide();
            string dataKey = _keysRepository.Provide<TData>();
            string serializedData = await _serializer.SerializeAsync(data);
            await _dataStorage.WriteAsync(dataKey, serializedData);

            Logger.Log(LogTag, $"Saved data of type \"{dataType}\"");
        }

        public async UniTask<TData> LoadAsync<TData>() where TData : ISaveData
        {
            string dataType = typeof(TData).Name;
            Logger.Log(LogTag, $"Loading data of type \"{dataType}\"...");

            string dataKey = _keysRepository.Provide<TData>();
            string serializedData = await _dataStorage.ReadAsync(dataKey);
            var data = await _serializer.DeserializeAsync<TData>(serializedData);

            Logger.Log(LogTag, $"Loaded data of type \"{dataType}");
            return data;
        }
    }
}
