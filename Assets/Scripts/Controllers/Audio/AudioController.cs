using UnityEngine;
using Behaviours;
using Helpers;
using Data;
using Zenject;

namespace Controllers
{
    sealed class AudioController : MonoBehaviour, IAudioPlayer
    {
        private AudioMixerVolumeMuter _audioMixerMuter;

        private AudioSourcePool _audioSourcePool;
        private AudioEventsHandler _audioEventsHandler;
        private BackgroundMusic _backgroundMusic;

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

        [Inject]
        private void Construct(DatasBundle datasBundle)
        {
            Debug.Log("ConstructAudio");
            var dataResourcePrefabs = datasBundle.GetData<DataResourcePrefabs>();

            _audioMixerMuter = datasBundle.GetData<AudioMixerVolumeMuter>();

            _audioSourcePool = new AudioSourcePool(dataResourcePrefabs);
            _backgroundMusic = new BackgroundMusic(dataResourcePrefabs);
        }

        private void Initialize()
        {
            _audioEventsHandler = new AudioEventsHandler(this);
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
        public void PlayBackgroundMusic(AudioClip backgroundMusic)
        {
            _backgroundMusic.StartPlayingMusic(backgroundMusic);
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