using System;
using Cysharp.Threading.Tasks;
using Data;
using Helpers;
using Behaviours;

namespace Controllers
{
    sealed partial class SaveSystemController : IInitialization, IEventSubscription,
        IEventListener<SaveEvent>, IEventListener<LoadEvent>, IDisposable
    {
        private ISaveSystem _saveSystem;
        private SaveDataContainer _saveDataContainer;

        public SaveSystemController()
        {
            Initialization();
            Subscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        public void Initialization()
        {
            _saveSystem = new DefaultSaveSystemFactory().CreateAndReturn();
            _saveDataContainer = new SaveDataContainer();
        }

        private void SaveData()
        {
            var saveData = _saveDataContainer.SaveData;
            ProcessAsync
                (
                () => _saveSystem.SaveAsync(saveData)
                )
                .Forget();
        }
        private async UniTaskVoid LoadData()
        {
            SaveData loadedData;
            loadedData = await _saveSystem.LoadAsync<SaveData>();
            SendSaveDataEvent.Trigger(loadedData);

        }


        #region Events

        public void OnEventTrigger(SaveEvent eventType)
        {
            SaveData();
        }
        public void OnEventTrigger(LoadEvent eventType)
        {
            LoadData().Forget();
        }
        public void Subscribe()
        {
            this.EventStartListening<SaveEvent>();
            this.EventStartListening<LoadEvent>();
        }
        public void Unsubscribe()
        {
            this.EventStopListening<SaveEvent>();
            this.EventStopListening<LoadEvent>();
        }

        #endregion


    }
}
