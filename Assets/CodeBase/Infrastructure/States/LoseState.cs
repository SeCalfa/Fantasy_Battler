using CodeBase.Logic.OrcComponents;
using CodeBase.Logic.PlayerComponents;
using CodeBase.Logic.UI;
using CodeBase.Services.Locator;

namespace CodeBase.Infrastructure.States
{
    public class LoseState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly GameObjectsLocator gameObjectsLocator;

        public LoseState(GameStateMachine gameStateMachine, GameObjectsLocator gameObjectsLocator)
        {
            this.gameStateMachine = gameStateMachine;
            this.gameObjectsLocator = gameObjectsLocator;
        }

        public void Enter()
        {
            gameObjectsLocator.GetGameObjectByName(Constance.CanvasName).GetComponent<MainCanvas>().LosePanelOn();
        }

        public void EnterWithParam(string param)
        {
            
        }

        public void Exit()
        {
            gameObjectsLocator.GetGameObjectByName(Constance.CanvasName).GetComponent<MainCanvas>().LosePanelOff();
            gameObjectsLocator.GetGameObjectByName(Constance.PlayerName).GetComponent<Player>().Respawn();
            gameObjectsLocator.GetGameObjectByName(Constance.OrcName).GetComponent<Orc>().Respawn();
        }
    }
}