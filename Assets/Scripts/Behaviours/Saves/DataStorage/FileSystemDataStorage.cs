using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using JetBrains.Annotations;
using Cysharp.Threading.Tasks;

namespace Behaviours
{
    sealed class FileSystemDataStorage : IDataStorage
    {
        [NotNull] private readonly string _folderPath;
        [NotNull] private readonly string _fileExtension;
        [NotNull] private readonly CancellationTokenSource _cts = new();


        public FileSystemDataStorage([NotNull] string folderPath, [NotNull] string fileExtension)
        {
            _folderPath = folderPath ?? throw new ArgumentNullException(nameof(folderPath));
            _fileExtension = fileExtension ?? throw new ArgumentNullException(nameof(fileExtension));
        }

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }


        public UniTask<bool> ExistsAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return UniTask.FromResult(false);

            string filePath = GetFilePath(key);
            bool exists = File.Exists(filePath);

            return UniTask.FromResult(exists);
        }


        public async UniTask<IEnumerable<KeyValuePair<string, string>>> ReadAsync(IReadOnlyCollection<string> keys)
        {
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));

            List<KeyValuePair<string, string>> readData = new();

            foreach (string key in keys)
            {
                string serializedData = await ReadAsync(key);
                readData.Add(new KeyValuePair<string, string>(key, serializedData));
            }

            return readData;
        }

        public async UniTask<string> ReadAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            string filePath = GetFilePath(key);
            return await File.ReadAllTextAsync(filePath, _cts.Token);
        }


        public async UniTask WriteAsync(IReadOnlyCollection<KeyValuePair<string, string>> serializedData)
        {
            if (serializedData == null)
                throw new ArgumentNullException(nameof(serializedData));

            foreach ((string key, string data) in serializedData)
                await WriteAsync(key, data);
        }

        public async UniTask WriteAsync(string key, string serializedData)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (string.IsNullOrWhiteSpace(serializedData))
                throw new ArgumentNullException(nameof(serializedData));

            string filePath = GetFilePath(key);
            await File.WriteAllTextAsync(filePath, serializedData, _cts.Token);
        }


        public async UniTask DeleteAsync(IReadOnlyCollection<string> keys)
        {
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));

            foreach (string key in keys)
                await DeleteAsync(key);
        }

        public UniTask DeleteAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            string filePath = GetFilePath(key);
            File.Delete(filePath);

            return UniTask.CompletedTask;
        }


        private string GetFilePath(string key) =>
            Path.Combine(_folderPath, key + "." + _fileExtension);
    }
}
