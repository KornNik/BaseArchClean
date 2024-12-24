using UnityEngine;
using Behaviours;
using Helpers;
using Data;

namespace Controllers
{
    sealed class AudioController : MonoBehaviour, IAudioPlayer
    {
        private AudioSource _audioSourcePoolablePrefab;
        private AudioMixerVolumeMuter _audioMixerMuter;

        private AudioSourcePool _audioSourcePool;
        private AudioEventsHandler _audioEventsHandler;

        private EventSubscriptionWraper _eventSubscriptionWrapper;

        public void Awake()
        {
            Initialize();
            FillSubscriptions();
        }
        private void OnEnable()
        {
            _eventSubscriptionWrapper.Subscribe();
        }
        private void OnDisable()
        {
            _eventSubscriptionWrapper.Unsubscribe();
        }

        private void Initialize()
        {
            _audioSourcePoolablePrefab = Services.Instance.DatasBundle.ServicesObject.
                GetData<DataResourcePrefabs>().GetAudioPrefab
                (AudioTypes.PoolableSourcePrefab).GetComponent<AudioSource>();

            _audioMixerMuter = Services.Instance.DatasBundle.ServicesObject.
                GetData<AudioMixerVolumeMuter>();

            _audioSourcePool = new AudioSourcePool(_audioSourcePoolablePrefab);
            _audioEventsHandler = new AudioEventsHandler();
            _eventSubscriptionWrapper = new EventSubscriptionWraper();
        }
        private void FillSubscriptions()
        {
            _eventSubscriptionWrapper.AddEvent(_audioEventsHandler);
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