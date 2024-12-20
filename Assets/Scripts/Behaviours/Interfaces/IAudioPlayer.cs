namespace Behaviours
{
    interface IAudioPlayer
    {
        public void PlaySound(SoundEventInfo soudnInfo);
        public void SwitchMutedState();
        public void SetSoundStatus(bool status);
        public bool IsSoundMuted();
    }
}
