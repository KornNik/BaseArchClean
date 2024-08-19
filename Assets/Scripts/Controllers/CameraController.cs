using CameraScripts;
using UnityEngine;

namespace Controllers
{
    internal class CameraController : MonoBehaviour, IInitialization
    {
        private CameraModel _cameraModel;
        private CameraMovement _cameraMovement;

        public void Initialization()
        {
            _cameraModel = new CameraModel();
            _cameraMovement = new CameraMovement();
            _cameraModel.Initialization();
        }

        public void LateUpdate()
        {

        }
    }
}
