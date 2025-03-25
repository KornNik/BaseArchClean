using Cysharp.Threading.Tasks;
using Helpers;

namespace Behaviours
{
    sealed class GameStateInitializerAsync : BaseAddressablesInstanceInitializer
    {

        public override async UniTask InitializationAsync()
        {
            var result = await AddressablesInstance<GameStateBehaviour>
                (Services.Instance.AddressablesReference.ServicesObject.
                GetGameStateRef());
            await UniTask.Yield();
        }
    }
}
