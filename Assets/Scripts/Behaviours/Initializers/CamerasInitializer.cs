using UnityEngine;
using Helpers.Extensions;
using Helpers.AssetsPath;
using Data;
using Helpers;
using Controllers;

namespace Behaviours
{
   sealed class CamerasInitializer : IInitialization
    {
        private CamerasInitilaizationData _camerasData;
        public void Initialization()
        {
            CamerasDataInitialization();
            MainCameraInitialization();
        }

        private void CamerasDataInitialization()
        {
            var dataResources = Services.Instance.DatasBundle.ServicesObject.GetData<CamerasInitilaizationData>();
            _camerasData = dataResources;
        }
        private void MainCameraInitialization()
        {
            var mainCameraResource = CustomResources.Load<Camera>(CamerasAssetPath.CamerasPath[CameraTypes.MainCamera]);
            var mainCameraObject = Object.Instantiate(mainCameraResource, _camerasData.GetMainCameraPosition(), Quaternion.identity);

            Services.Instance.CameraService.SetObject(mainCameraObject);
        }
    }
}
