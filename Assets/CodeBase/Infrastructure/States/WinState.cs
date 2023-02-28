using CodeBase.Logic.OrcComponents;
using CodeBase.Logic.PlayerComponents;
using CodeBase.Logic.UI;
using CodeBase.Services.Locator;

namespace CodeBase.Infrastructure.States
{
    public class WinState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly GameObjectsLocator gameObjectsLocator;

        public WinState(GameStateMachine gameStateMachine, GameObjectsLocator gameObjectsLocator)
        {
            this.gameStateMachine = gameStateMachine;
            this.gameObjectsLocator = gameObjectsLocator;
        }

        public void Enter()
        {
            gameObjectsLocator.GetGameObjectByName(Constance.CanvasName).GetComponent<MainCanvas>().WinPanelOn();
        }

        public void EnterWithParam(string param)
        {

        }

        public void Exit()
        {
            gameObjectsLocator.GetGameObjectByName(Constance.CanvasName).GetComponent<MainCanvas>().WinPanelOff();
            gameObjectsLocator.GetGameObjectByName(Constance.PlayerName).GetComponent<Player>().Respawn();
            gameObjectsLocator.GetGameObjectByName(Constance.OrcName).GetComponent<Orc>().Respawn();
        }
    }
}