using Cysharp.Threading.Tasks;
using UI;

namespace Behaviours
{
    sealed class LoadingScreenShowAsync : IInitializationAsync
    {
        public async UniTask InitializationAsync()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.LoadingScreen);
            await UniTask.Yield();
        }
    }
}
