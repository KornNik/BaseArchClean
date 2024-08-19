using UnityEngine;
using Behaviours;
using Helpers;
using Helpers.AssetsPath;
using Helpers.Extensions;
using Data;

namespace Controllers
{
    sealed class AudioController : MonoBehaviour
    {
        private AudioSource _audioSourceBackground;
        private AudioSource _audioSourcePoolablePrefab;
        private AudioMixerVolumeMuter _audioMixerMuter;

        private AudioClip _audioClip;
        private AudioSourcePool _audioSourcePool;
        private AudioEventsHandler _audioEventsHandler;

        public void Awake()
        {
            _audioSourceBackground = CustomResources.Load<AudioSource>
                (AudioAssetPath.AudioPath[AudioTypes.BackgroundSourcePrefab]);
            _audioSourcePoolablePrefab = CustomResources.Load<AudioSource>
                (AudioAssetPath.AudioPath[AudioTypes.PoolableSourcePrefab]);
            _audioSourcePool = new AudioSourcePool(_audioSourcePoolablePrefab);
            _audioEventsHandler = new AudioEventsHandler();
            _audioMixerMuter = Services.Instance.DatasBundle.ServicesObject.GetData<AudioMixerVolumeMuter>();
        }
        
        private void Update()
        {
            if (!_audioSourceBackground.isPlaying && !ReferenceEquals(_audioClip,null))
            {
                _audioClip = null;
            }
        }

        public void PlaySound(SoundEventInfo soudnInfo)
        {
            if (soudnInfo.IsOneShot)
            {
                _audioSourcePool.PlayAtPointOneShot(soudnInfo.AudioClip, soudnInfo.PlayPosition, soudnInfo.SoundVolume);
            }
            else
            {
                _audioSourcePool.PlayAtPoint(soudnInfo.AudioClip, soudnInfo.PlayPosition, soudnInfo.SoundVolume);
            }
        }

        public void SwitchMutedState()
        {
            _audioMixerMuter.Muted = !_audioMixerMuter.Muted;
        }
        public void SetSoundStatus(bool status)
        {
            _audioMixerMuter.Muted = status;
        }
        public bool IsSoundMuted()
        {
            return _audioMixerMuter.Muted;
        }
    }
}