using Cysharp.Threading.Tasks;

namespace Behaviours
{
    interface ISerializer
    {
        UniTask<string> SerializeAsync<TData>(TData data);
        UniTask<TData> DeserializeAsync<TData>(string serializedData);
    }
}
