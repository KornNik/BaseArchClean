using Helpers;
using Controllers;
using Cysharp.Threading.Tasks;

namespace Behaviours
{
    sealed class AudioInitializerAsync : BaseAddressablesInstanceInitializer
    {
        public override async UniTask InitializationAsync()
        {
            var result = await AddressablesInstance<AudioController>
                (Services.Instance.AddressablesReference.ServicesObject.
                GetAudioRef(AudioTypes.AudioController));

            await UniTask.Yield();
        }
    }
}
