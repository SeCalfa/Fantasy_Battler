namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly SceneLoader sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            this.gameStateMachine = gameStateMachine;
            this.sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            sceneLoader.Load(Constance.InitScene, LoadGameLevel);
        }

        public void EnterWithParam(string param)
        {
            
        }

        public void Exit()
        {
            
        }

        private void LoadGameLevel()
        {
            gameStateMachine.Enter<LoadLevelState>(Constance.GameScene);
        }
    }
}
