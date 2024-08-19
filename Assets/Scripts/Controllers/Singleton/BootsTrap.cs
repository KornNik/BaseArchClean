using Helpers;
using Behaviours;

namespace Controllers
{
    sealed class BootsTrap : PersistanceSingleton<BootsTrap>
    {
        private SystemsInitializer _systemsInitializer;
        private ComponentsInitializer _componentsInitializer;

        private void Start()
        {
            InitializationComponents();
        }
        private void InitializationComponents()
        {
            _systemsInitializer = new SystemsInitializer();
            _componentsInitializer = new ComponentsInitializer();

            _systemsInitializer.Initialization();
            _componentsInitializer.Initialization();
        }
    }
}
