using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace Behaviours
{
    sealed class JsonUtilitySerializer : ISerializer
    {
        public UniTask<string> SerializeAsync<TData>(TData data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            string json = JsonUtility.ToJson(data);
            return UniTask.FromResult(json);
        }

        public UniTask<TData> DeserializeAsync<TData>(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new ArgumentNullException(nameof(json));

            var data = JsonUtility.FromJson<TData>(json);
            return UniTask.FromResult(data);
        }
    }
}
