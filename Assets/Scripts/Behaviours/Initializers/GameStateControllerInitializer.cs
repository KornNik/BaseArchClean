using Controllers;
using Helpers;
using Helpers.AssetsPath;
using Helpers.Extensions;

namespace Behaviours
{
    class GameStateControllerInitializer : IInitialization
    {
        public void Initialization()
        {
            var gameStateBeh = CustomResources.Load<GameStateBehaviour>(ResourcesPathManager.STATE_BEHAVIOUR);
            Services.Instance.GameStateBehavior.SetObject(gameStateBeh);
        }
    }
}