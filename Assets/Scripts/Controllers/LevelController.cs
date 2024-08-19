using Data;
using UnityEngine;

namespace Controllers
{
    class LevelController
    {
        public void LoadLevel(LevelsBundle levelsBundle)
        {
            var levelData = levelsBundle.GetCurrentLevelData();
            var level = Object.Instantiate(levelData.GetPrefab(), levelData.GetLevelPosition(), Quaternion.identity);
        }

    }
}
