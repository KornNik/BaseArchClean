using UnityEngine;
using Data;
using Behaviours;
using Controllers;
using Helpers;

namespace CameraScripts
{
    internal class CameraModel : IInitialization
    {
        private Camera _camera;
        private CameraData _cameraData;

        public void Initialization()
        {
            _camera = Camera.main;
            _cameraData = Services.Instance.DatasBundle.ServicesObject.GetData<CameraData>();
        }
    }
}