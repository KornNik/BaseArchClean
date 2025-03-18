using System;
using UnityEngine;
using JetBrains.Annotations;
using Cysharp.Threading.Tasks;
using Data;
using Helpers;
using Behaviours;

namespace Controllers
{
    sealed partial class SaveSystemController : IInitialization, IEventSubscription, IDisposable, IEventListener<SaveEvent>, IEventListener<LoadEvent>
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
            _saveSystem = new SaveSystem
                (
                 new NewtonsoftSerializer(),
                 new FileSystemDataStorage(Application.persistentDataPath, ".ext"),
                 new SaveDataKeysProvider(),
                 new TimeStempPorvidor()
                );
            _saveDataContainer = new SaveDataContainer();
        }

        private void SaveData([NotNull]ISaveData saveData)
        {
            var convertedData = saveData as SaveData;
            ProcessAsync
                (
                () => _saveSystem.SaveAsync(convertedData)
                ).Forget();
        }
        private async UniTaskVoid LoadData()
        {
            SaveData loadedData;
            loadedData = await _saveSystem.LoadAsync<SaveData>();
            SendSaveDataEvent.Trigger(loadedData);

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
        public void OnEventTrigger(SaveEvent eventType)
        {
            SaveData(_saveDataContainer.SaveData);
        }

        public void OnEventTrigger(LoadEvent eventType)
        {
            LoadData().Forget();
        }
    }
}
