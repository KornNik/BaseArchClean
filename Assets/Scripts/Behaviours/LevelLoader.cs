using UnityEngine;
using Data;
using Helpers;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Behaviours
{
    class LevelLoader : ILevelLoader
    {
        private GameObject _level;
        private LevelData _levelData;
        private LevelsBundle _levelsBundle;

        private int _levelIndex = 0;

        public LevelLoader()
        {
            _levelsBundle = Services.Instance.DataResourcePrefabs.ServicesObject.GetLevelsBundle();
        }

        public void LoadLevelByIndex(int index)
        {
            LoadLevelVisuals(index).Forget();
        }
        public bool LoadNextLevel()
        {
            if (!IsLastLevel())
            {
                _levelIndex++;
                LoadLevelByIndex(_levelIndex);
                return true;
            }
            return false;
        }
        public void ResetLevels()
        {
            _levelIndex = 0;
        }
        public void ClearLevelFull()
        {
            if (!ReferenceEquals(_level, null))
            {
                Addressables.ReleaseInstance(_level);
                _level = null;
            }
        }
        public bool IsLastLevel()
        {
            return _levelsBundle.IsLastLevelByIndex(_levelIndex);
        }

        private async UniTaskVoid LoadLevelVisuals(int index)
        {
            _levelData = _levelsBundle.GetRandomLevelData();
            await LoadLevelObject();
            _level.transform.localPosition = Vector3.zero;
            _level.transform.localRotation = Quaternion.identity;
        }
        private async UniTask LoadLevelObject()
        {
            var loadablePrefab = _levelData.LevelReference;
            var handle = Addressables.InstantiateAsync(loadablePrefab);
            await handle.ToUniTask();
            if(handle.Status == AsyncOperationStatus.Succeeded)
            {
                _level = handle.Result;
            }
        }
    }
}
