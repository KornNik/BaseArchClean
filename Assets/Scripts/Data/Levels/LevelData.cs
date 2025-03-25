using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data
{
    [CreateAssetMenu(fileName ="LevelData",menuName ="Data/Level/LevelData")]
    class LevelData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private AssetReference _levelRef;
        [SerializeField] private Vector3 _levelPosition;

        public AssetReference LevelReference => _levelRef;
        public Vector3 LevelPosition => _levelPosition;
        public string Name => _name;
    }
}
