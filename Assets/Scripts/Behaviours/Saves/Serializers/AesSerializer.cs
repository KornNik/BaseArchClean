using Behaviours;
using Cysharp.Threading.Tasks;
using System;
using UnityCipher;

namespace Assets.Scripts.Behaviours.Saves.Serializers
{
    sealed class AesSerializer : ISerializer
    {
        private readonly ISerializer _baseSerializer;
        private readonly IKeysProvider _keysProvider;

        public AesSerializer( ISerializer baseSerializer,IKeysProvider keysProvider)
        {
            _baseSerializer = baseSerializer ?? throw new ArgumentNullException(nameof(baseSerializer));
            _keysProvider = keysProvider ?? throw new ArgumentNullException(nameof(keysProvider));
        }

        public async UniTask<string> SerializeAsync<TData>(TData data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            string password = _keysProvider.Provide<TData>();
            string serializeData = await _baseSerializer.SerializeAsync(data);

            return RijndaelEncryption.Encrypt(serializeData, password);
        }

        public UniTask<TData> DeserializeAsync<TData>(string encryptedData)
        {
            if (string.IsNullOrWhiteSpace(encryptedData))
                throw new ArgumentNullException(nameof(encryptedData));

            string password = _keysProvider.Provide<TData>();
            string decryptedData = RijndaelEncryption.Decrypt(encryptedData, password);

            return _baseSerializer.DeserializeAsync<TData>(decryptedData);
        }
    }
}
