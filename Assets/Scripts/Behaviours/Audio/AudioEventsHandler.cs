using Helpers;

namespace Behaviours
{
    class AudioEventsHandler : IEventListener<MakeSoundEvent>, IEventListener<MuteSoundEvent>,
        IEventSubscription
    {
        private IAudioPlayer _audioPlayer;

        public AudioEventsHandler()
        {
            _audioPlayer = Services.Instance.AudioPlayer.ServicesObject;
        }

        public void OnEventTrigger(MakeSoundEvent eventType)
        {
            _audioPlayer.PlaySound(eventType.SoundData);
        }

        public void OnEventTrigger(MuteSoundEvent eventType)
        {
            _audioPlayer.SetSoundStatus(eventType.MutedInfo.IsMuted);
        }

        public void Subscribe()
        {
            this.EventStartListening<MakeSoundEvent>();
            this.EventStartListening<MuteSoundEvent>();
        }

        public void Unsubscribe()
        {
            this.EventStopListening<MakeSoundEvent>();
            this.EventStopListening<MuteSoundEvent>();
        }
    }
}