using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class BackgroundMusic
    {
        private AudioSource _audioSource;

        public BackgroundMusic(DataResourcePrefabs dataResource)
        {
            Initialize(dataResource);
            Configure();
        }
        public BackgroundMusic(AudioSource audioSource)
        {
            _audioSource = audioSource;
            Configure();
        }

        public void StartPlayingMusic(AudioClip audioClip)
        {
            if (_audioSource.isPlaying)
            {
                StopPlayingMusic();
            }
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }
        public void StopPlayingMusic()
        {
            _audioSource.Stop();
            _audioSource.clip = null;
        }

        private void Initialize(DataResourcePrefabs dataResource)
        {
            var audioSourcePrefab = dataResource.GetAudioPrefab
                (AudioTypes.BackgroundSourcePrefab).GetComponent<AudioSource>();
            _audioSource = GameObject.Instantiate(audioSourcePrefab, Vector3.zero, Quaternion.identity);
        }
        private void Configure()
        {
            _audioSource.loop = true;
        }
    }
}
