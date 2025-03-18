using Behaviours;
using System;

namespace Data
{
    [Serializable]
    sealed class SaveData : ISaveData
    {
        public long Timestamp { get; set; }

        public SettingsData SettingsData;
        public AudioData AudioData;

        public SaveData(SettingsData settingsData, AudioData audioData)
        {
            SettingsData = settingsData;
            AudioData = audioData;
        }
    }
    [Serializable]
    sealed class SettingsData : ISaveData
    {
        public long Timestamp { get; set; }

        public int VsyncCount;
        public int FrameRate;

        public SettingsData(int vsyncCount, int frameRate)
        {
            VsyncCount = vsyncCount;
            FrameRate = frameRate;
        }
    }
    [Serializable]
    sealed class AudioData : ISaveData
    {
        public long Timestamp { get; set; }

        public float Volume;
        public bool IsMuted;

        public AudioData(float volume, bool isMuted)
        {
            Volume = volume;
            IsMuted = isMuted;
        }
    }
}
