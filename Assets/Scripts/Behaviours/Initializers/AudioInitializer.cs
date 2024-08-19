using Helpers;
using Helpers.Extensions;
using Helpers.AssetsPath;
using Controllers;
using UnityEngine;

namespace Behaviours
{
    class AudioInitializer : IInitialization
    {
        public void Initialization()
        {
            var audioController = GameObject.Instantiate(CustomResources.Load<AudioController>
                (AudioAssetPath.AudioPath[AudioTypes.AudioController]));

            Services.Instance.AudioController.SetObject(audioController);
        }
    }
}
