using Data;
using Helpers;
using System.Threading.Tasks;
using UnityEngine;

namespace Behaviours
{
    sealed class CameraInitializerAsync : IInitializationAsync
    {
        private CamerasInitilaizationData _camerasData;

        public async Task InitializationAsync()
        {
            CamerasDataInitialization();
            MainCameraInitialization();

            await Task.Yield();
        }

        private void CamerasDataInitialization()
        {
            var dataResources = Services.Instance.DatasBundle.ServicesObject.GetData<CamerasInitilaizationData>();
            _camerasData = dataResources;
        }
        private void MainCameraInitialization()
        {
            var mainCameraResource = Services.Instance.DatasBundle.ServicesObject.GetData<DataResourcePrefabs>().GetCamerPrefab();
            var mainCameraObject = GameObject.Instantiate(mainCameraResource, _camerasData.GetMainCameraPosition(), Quaternion.identity).GetComponent<Camera>();

            Services.Instance.CameraService.SetObject(mainCameraObject);
        }
    }
}
