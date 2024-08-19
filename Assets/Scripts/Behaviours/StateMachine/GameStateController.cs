namespace Behaviours
{
    internal class GameStateController : BaseStateController
    {
        private IState _menuState;
        private IState _pauseState;
        private IState _gameState;

        public GameStateController()
        {
            InitializeStates();
            StartState(MenuState);
        }

        public IState MenuState => _menuState;
        public IState PauseState => _pauseState;
        public IState GameState => _gameState;

        protected override void InitializeStates()
        {
            _menuState = new MenuState(this);
            _pauseState = new PauseState(this);
            _gameState = new GameState(this);
        }
    }
}