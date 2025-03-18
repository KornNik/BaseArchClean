using Helpers;
using UI;
using Helpers.Extensions;
using Controllers;

namespace Behaviours
{
    sealed class GameState : BaseState
    {
        private InputActions _inputs;
        public GameState(GameStateController stateController) : base(stateController)
        {
            _inputs = Services.Instance.Inputs.ServicesObject;
        }

        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
        }

        public override void ExitState()
        {
        }

        public override void LogicFixedUpdate()
        {
        }

        public override void LogicUpdate()
        {
            var isSave = _inputs.PlayerActionList[InputActionManager.INSPECT].IsPressed();
            var isLoad = _inputs.PlayerActionList[InputActionManager.INTERACT].IsPressed();

            if (isSave)
            {
                SaveEvent.Trigger();
            }
            if (isLoad)
            {
                LoadEvent.Trigger();
            }
        }
    }
}
