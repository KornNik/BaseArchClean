using Helpers;
using Cysharp.Threading.Tasks;
using Controllers;


namespace Behaviours
{
    sealed class SaveSystemInitializerAsync : IInitializationAsync
    {
        public async UniTask InitializationAsync()
        {
            var saveController = new SaveSystemController();
            Services.Instance.SaveService.SetObject(saveController);

            await UniTask.Yield();
        }
    }
}
