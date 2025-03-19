using UnityEngine;

namespace Behaviours
{
    sealed class DefaultSaveSystemFactory : ISaveSystemFactory
    {
        public SaveSystem CreateAndReturn()
        {
            var saveSystem = new SaveSystem
                (
                new NewtonsoftSerializer(),
                new FileSystemDataStorage(Application.persistentDataPath, ".ext"),
                new SaveDataKeysProvider(),
                new TimeStempPorvidor()
                );

            return saveSystem;
        }
    }
    interface ISaveSystemFactory
    {
        SaveSystem CreateAndReturn();
    }
}
