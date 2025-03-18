using Data;
using Helpers;

namespace Controllers
{
    struct SendSaveDataEvent
    {
        private SaveData _saveData;
        private static SendSaveDataEvent _sendSaveDataEvent;

        public SaveData SaveData  => _saveData;

        public static void Trigger(SaveData saveData)
        {
            _sendSaveDataEvent._saveData = saveData;
            EventManager.TriggerEvent(_sendSaveDataEvent);
        }
    }
}
