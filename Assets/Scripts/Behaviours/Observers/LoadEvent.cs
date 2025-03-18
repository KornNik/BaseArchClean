using Helpers;

namespace Controllers
{
    struct LoadEvent
    {
        private static LoadEvent _loadEvent;

        public static void Trigger()
        {
            EventManager.TriggerEvent(_loadEvent);
        }
    }
}
