using Controllers;
using UI;

namespace Behaviours
{
    class ScreenInitializer : IInitialization
    {
        public void Initialization()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.MainMenu);
        }
    }
}
