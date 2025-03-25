using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;

namespace Behaviours
{
    abstract class BaseAddressablesInstanceInitializer : IInitializationAsync
    {
        public abstract UniTask InitializationAsync();
        public async UniTask<T> AddressablesInstance<T>(AssetReference neededReference)
        {
            var loadablePrefab = neededReference;
            var handle = Addressables.InstantiateAsync(loadablePrefab);
            await handle.ToUniTask();

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                var neededObject = handle.Result.GetComponent<T>();
                return neededObject;
            }
            throw new NullReferenceException();
        }
    }
}
