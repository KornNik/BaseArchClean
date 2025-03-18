using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using System;

namespace Behaviours
{
    sealed class NewtonsoftSerializer : ISerializer
    {
        public UniTask<string> SerializeAsync<TData>(TData data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            string json = JsonConvert.SerializeObject(data);
            return UniTask.FromResult(json);
        }

        public UniTask<TData> DeserializeAsync<TData>(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new ArgumentNullException(nameof(json));

            var data = JsonConvert.DeserializeObject<TData>(json);
            return UniTask.FromResult(data);
        }
    }
}
