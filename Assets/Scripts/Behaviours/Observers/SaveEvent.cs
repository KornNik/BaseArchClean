using Helpers;
using Behaviours;

namespace Controllers
{
    struct SaveEvent
    {
        private static SaveEvent _saveEvent;
        private ISaveData _saveData;

        public ISaveData SaveData => _saveData;

        public static void Trigger()
        {
            EventManager.TriggerEvent(_saveEvent);
        }
    }
}
