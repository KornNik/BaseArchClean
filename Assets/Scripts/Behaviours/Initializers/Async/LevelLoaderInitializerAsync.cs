using Helpers;
using System.Threading.Tasks;

namespace Behaviours
{
    sealed class LevelLoaderInitializerAsync : IInitializationAsync
    {
        public async Task InitializationAsync()
        {
            var lelveLoader = new LevelLoader();
            Services.Instance.LevelLoader.SetObject(lelveLoader);
            await Task.Yield();
        }
    }
}
