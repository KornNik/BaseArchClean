using System.Collections.Generic;
using System.Threading.Tasks;

namespace Behaviours
{
    abstract class BaseInitializerAsync : IInitializationAsync
    {
        private List<IInitializationAsync> _initializers = new List<IInitializationAsync>();

        public List<IInitializationAsync> Initializers => _initializers;

        public async Task InitializationAsync()
        {
            FillInitializers();
            await InitializeAsync();
        }
        public async Task InitializeAsync()
        {
            foreach (var initializer in _initializers)
            {
                await initializer.InitializationAsync();
            }
        }
        protected abstract void FillInitializers();
    }
}
