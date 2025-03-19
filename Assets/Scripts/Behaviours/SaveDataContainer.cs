using Controllers;
using Data;
using Helpers;
using System;

namespace Behaviours
{
    sealed class SaveDataContainer : IEventListener<SendSaveDataEvent>, IEventSubscription, IDisposable
    {
        private SaveData _saveData;

        public SaveDataContainer()
        {
            var defAudioData = Services.Instance.DatasBundle.ServicesObject.
                GetData<DefaultAudioData>();
            var defSettingsData = Services.Instance.DatasBundle.ServicesObject.
                GetData<DefaultSettingsData>();

            var settingsData = new SettingsData(defSettingsData.VsyncCount, defSettingsData.FrameRate);
            var audioData = new AudioData(defAudioData.Volume, defAudioData.IsMuted);

            _saveData = new SaveData(settingsData, audioData);

            Subscribe();
        }
        public void Dispose()
        {
            Unsubscribe();
        }

        private void UpdateData(SaveData saveData)
        {
            _saveData = saveData;
        }

        public SaveData SaveData => _saveData;

        public void OnEventTrigger(SendSaveDataEvent eventType)
        {
            UpdateData(eventType.SaveData);
        }

        public void Subscribe()
        {
            this.EventStartListening<SendSaveDataEvent>();
        }

        public void Unsubscribe()
        {
            this.EventStopListening<SendSaveDataEvent>();
        }
    }
}
