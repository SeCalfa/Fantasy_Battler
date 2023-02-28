using CodeBase.Logic.UI;
using CodeBase.Services.Locator;

namespace CodeBase.Infrastructure.States
{
    public class TutorialState : IState
    {
        private readonly GameObjectsLocator gameObjectsLocator;

        public TutorialState(GameObjectsLocator gameObjectsLocator)
        {
            this.gameObjectsLocator = gameObjectsLocator;
        }

        public void Enter()
        {
            gameObjectsLocator.GetGameObjectByName(Constance.CanvasName).GetComponent<MainCanvas>().TutorialPanelOn();
        }

        public void EnterWithParam(string param)
        {
            
        }

        public void Exit()
        {
            gameObjectsLocator.GetGameObjectByName(Constance.CanvasName).GetComponent<MainCanvas>().TutorialPanelOff();
        }
    }
}