using Behaviours;
using UnityEngine;
using Data;
using Zenject;

namespace Controllers
{
    class SettingsController : ISettingsController
    {
        private DefaultSettingsData _settingsData;

        public SettingsController()
        {

        }
        [Inject]
        private void Construct(DatasBundle datasBundle)
        {
            _settingsData = datasBundle.GetData<DefaultSettingsData>();
            LockedFPS();
        }
        public void LockedFPS()
        {
            QualitySettings.vSyncCount = _settingsData.VsyncCount;
            Application.targetFrameRate = _settingsData.FrameRate;
        }
        public void LockedCursor()
        {
            Cursor.lockState = _settingsData.LockMode;
            Cursor.visible = _settingsData.CursorVisibility;
        }
        public void UnLockedCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
