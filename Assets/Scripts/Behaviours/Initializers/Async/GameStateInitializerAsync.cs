using Data;
using Helpers;
using System.Threading.Tasks;
using UnityEngine;

namespace Behaviours
{
    sealed class GameStateInitializerAsync : IInitializationAsync
    {

        public async Task InitializationAsync()
        {
            var gameStatePrefab = Services.Instance.DatasBundle.ServicesObject.GetData<DataResourcePrefabs>().GetGameStatePrefab();
            var gameState = GameObject.Instantiate(gameStatePrefab).GetComponent<GameStateBehaviour>();
            Services.Instance.GameStateBehavior.SetObject(gameState);

            await Task.Yield();
        }
    }
}
