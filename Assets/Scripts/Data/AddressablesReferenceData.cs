using UnityEngine;
using Helpers;
using Helpers.Extensions;
using UnityEngine.AddressableAssets;

namespace Data
{
    [CreateAssetMenu(fileName = "AddressablesData", menuName = "Data/AddressablesData")]
    sealed class AddressablesReferenceData : ScriptableObject
    {
        [SerializeField] private AssetReference _cameraPrefab;
        [SerializeField] private AssetReference _gameStatePrefab;
        [SerializeField] private LevelsBundle _levelsBundle;

        [SerializeField] private SerializableDictionary<ScreenTypes, AssetReference> _screensPrefabs;
        [SerializeField] private SerializableDictionary<AudioTypes, AssetReference> _audioPrefabs;

        public AssetReference GetScreenRef(ScreenTypes screenType)
        {
            AssetReference screenPrefab = default;
            if (_screensPrefabs.Contains(screenType))
            {
                screenPrefab = _screensPrefabs[screenType];
            }
            return screenPrefab;
        }
        public AssetReference GetAudioRef(AudioTypes audioType)
        {
            AssetReference audioPrefab = default;
            if (_audioPrefabs.Contains(audioType))
            {
                audioPrefab = _audioPrefabs[audioType];
            }
            return audioPrefab;
        }
        public AssetReference GetCamerRef()
        {
            return _cameraPrefab;
        }
        public AssetReference GetGameStateRef()
        {
            return _gameStatePrefab;
        }
        public LevelsBundle GetLevelsBundle()
        {
            return _levelsBundle;
        }
    }
}
