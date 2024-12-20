using UnityEngine;
using Behaviours;
using Helpers;
using Data;

namespace Controllers
{
    sealed class AudioController : MonoBehaviour, IAudioPlayer
    {
        private AudioSource _audioSourceBackground;
        private AudioSource _audioSourcePoolablePrefab;
        private AudioMixerVolumeMuter _audioMixerMuter;

        private AudioClip _audioClip;
        private AudioSourcePool _audioSourcePool;
        private AudioEventsHandler _audioEventsHandler;

        public void Awake()
        {
            _audioSourceBackground = Services.Instance.DatasBundle.ServicesObject.
                GetData<DataResourcePrefabs>().GetAudioPrefab
                (AudioTypes.BackgroundSourcePrefab).GetComponent<AudioSource>();
            _audioSourcePoolablePrefab = Services.Instance.DatasBundle.ServicesObject.
                GetData<DataResourcePrefabs>().GetAudioPrefab
                (AudioTypes.PoolableSourcePrefab).GetComponent<AudioSource>();

            _audioSourcePool = new AudioSourcePool(_audioSourcePoolablePrefab);
            _audioEventsHandler = new AudioEventsHandler();
            _audioMixerMuter = Services.Instance.DatasBundle.ServicesObject.GetData<AudioMixerVolumeMuter>();
        }

        private void Update()
        {
            if (!_audioSourceBackground.isPlaying && !ReferenceEquals(_audioClip, null))
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