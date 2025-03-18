using UnityEngine;
using System.Collections.Generic;

namespace Behaviours
{
    internal sealed class Batch
    {
        private const string LogTag = nameof(BatchDataStorage);
        private static readonly ILogger Logger = Debug.unityLogger;

        private readonly Dictionary<string, string> _writeDiffs = new();
        private readonly HashSet<string> _deleteDiffs = new();

        public IEnumerable<KeyValuePair<string, string>> WriteDiffs => _writeDiffs;
        public IEnumerable<string> DeleteDiffs => _deleteDiffs;


        public void CollectWriteDiffs(IEnumerable<KeyValuePair<string, string>> serializedData)
        {
            foreach ((string key, string data) in serializedData)
                CollectWriteDiff(key, data);
        }

        public void CollectWriteDiff(string key, string serializedData)
        {
            _deleteDiffs.Remove(key);
            _writeDiffs[key] = serializedData;
            Logger.Log(LogTag, $"Collected write diff [{key}: {serializedData}]");
        }


        public void CollectDeleteDiffs(IEnumerable<string> keys)
        {
            foreach (string key in keys)
                CollectDeleteDiff(key);
        }

        public void CollectDeleteDiff(string key)
        {
            _writeDiffs.Remove(key);
            _deleteDiffs.Add(key);
            Logger.Log(LogTag, $"Collected delete diff \"{key}\"");
        }


        public void Clear()
        {
            _writeDiffs.Clear();
            _deleteDiffs.Clear();
            Logger.Log(LogTag, "Cleared");
        }
    }
}