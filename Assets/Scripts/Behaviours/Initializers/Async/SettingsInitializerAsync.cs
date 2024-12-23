using Helpers;
using System.Threading.Tasks;
using Controllers;

namespace Behaviours
{
    sealed class SettingsInitializerAsync : IInitializationAsync
    {
        public async Task InitializationAsync()
        {
            var settings = new SettingsController();
            Services.Instance.SettingsController.SetObject(settings);

            await Task.Yield();
        }
    }
}
