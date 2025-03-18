using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "AudioData", menuName = "Data/Settings/AudioData")]
    sealed class DefaultAudioData : ScriptableObject
    {
        [SerializeField, Range(-80, 0)]
        private float _volume;
        [SerializeField] private bool _isMuted;

        public float Volume => _volume;
        public bool IsMuted => _isMuted;
    }
}
