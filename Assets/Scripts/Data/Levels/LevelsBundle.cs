using UnityEngine;
using Helpers.Extensions;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelsBundle", menuName = "Data/Level/LevelsBundle")]
    class LevelsBundle : ScriptableObject
    {
        [SerializeField] private LevelData[] _levelsDatas;
        [SerializeField, ReadOnly] private int _levelIndex;

        public LevelData GetLevelData(int levelNumber)
        {
            if (levelNumber < _levelsDatas.Length)
            {
                var neededData = _levelsDatas[levelNumber];
                return neededData;
            }
            else
            {
                Debug.LogError($"{this.name} try to access to element that dont exist");
                return null;
            }
        }
        public LevelData GetCurrentLevelData()
        {
            if (_levelIndex < _levelsDatas.Length)
            {
                var neededData = _levelsDatas[_levelIndex];
                return neededData;
            }
            else
            {
                Debug.LogError($"{this.name} try to access to element that dont exist");
                return null;
            }
        }
    }
}
