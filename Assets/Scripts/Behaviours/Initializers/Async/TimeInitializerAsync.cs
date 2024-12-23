using Helpers;
using System.Threading.Tasks;
using Controllers;

namespace Behaviours
{
    sealed class TimeInitializerAsync : IInitializationAsync
    {
        public async Task InitializationAsync()
        {
            var timeController = new TimeController();
            Services.Instance.TimeController.SetObject(timeController);

            await Task.Yield();
        }
    }
}
