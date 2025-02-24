using Helpers;
using System.Threading.Tasks;
using Controllers;
using Data;
using UnityEngine;

namespace Behaviours
{
    sealed class AudioInitializerAsync : IInitializationAsync
    {
        public async Task InitializationAsync()
        {
            var audioControllerPrefab = Services.Instance.DatasBundle.ServicesObject.
                GetData<DataResourcePrefabs>().GetAudioPrefab(AudioTypes.AudioController);
            var audioController = GameObject.Instantiate(audioControllerPrefab).GetComponent<AudioController>();

            Services.Instance.AudioPlayer.SetObject(audioController);

            await Task.Yield();
        }
    }
}
