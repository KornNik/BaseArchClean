using Helpers;
using Behaviours;

namespace Controllers
{
    sealed class BootsTrapAsync : PersistanceSingleton<BootsTrapAsync>
    {
        private IInitializationAsync _systemsInitializer;
        private IInitializationAsync _componentsInitializer;

        private void Start()
        {
            InitializationComponents();
        }
        private async void InitializationComponents()
        {
            _systemsInitializer = new SystemInitializerAsync();
            _componentsInitializer = new ComponentInitializerAsync();

            await _systemsInitializer.InitializationAsync();
            await _componentsInitializer.InitializationAsync();
        }
    }
}
