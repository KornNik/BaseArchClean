using System.Collections.Generic;
using Helpers.Extensions;

namespace Helpers.AssetsPath
{
    sealed class AudioAssetPath
    {
        public static Dictionary<AudioTypes, string> AudioPath = new Dictionary<AudioTypes, string>
        {
            {
                AudioTypes.BackgroundSourcePrefab, StringBuilderExtender.CreateString
                    (ResourcesPathManager.AUDIO_FOLDER,ResourcesPathManager.AUDIO_BACKGROUND)
            },
            {
                AudioTypes.PoolableSourcePrefab, StringBuilderExtender.CreateString
                    (ResourcesPathManager.AUDIO_FOLDER,ResourcesPathManager.AUDIO_POOLABLE)
            },
            {
                AudioTypes.AudioController, StringBuilderExtender.CreateString
                (ResourcesPathManager.AUDIO_FOLDER,ResourcesPathManager.AUDIO_CONTROLLER)
            }
        };
    }
}