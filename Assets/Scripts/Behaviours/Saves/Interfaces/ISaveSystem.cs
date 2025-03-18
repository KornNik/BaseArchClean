using Cysharp.Threading.Tasks;

namespace Behaviours
{
    interface ISaveSystem
    {
        UniTask InitializeAsync();
        UniTask SaveAsync<TData>(TData data) where TData : ISaveData;
        UniTask<TData> LoadAsync<TData>() where TData : ISaveData;
    }
}
