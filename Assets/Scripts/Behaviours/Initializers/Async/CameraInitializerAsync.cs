using Cysharp.Threading.Tasks;
using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class CameraInitializerAsync : BaseAddressablesInstanceInitializer
    {
        private CamerasInitilaizationData _camerasData;

        public override async UniTask InitializationAsync()
        {
            CamerasDataInitialization();

            var result = await AddressablesInstance<Camera>
                (Services.Instance.AddressablesReference.ServicesObject.
                GetCamerRef());

            await UniTask.Yield();
        }

        private void CamerasDataInitialization()
        {
            var dataResources = Services.Instance.DatasBundle.ServicesObject.GetData<CamerasInitilaizationData>();
            _camerasData = dataResources;
        }
    }
}
