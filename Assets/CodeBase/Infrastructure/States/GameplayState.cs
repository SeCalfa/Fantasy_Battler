namespace CodeBase.Infrastructure.States
{
    public class GameplayState : IState
    {
        private readonly GameStateMachine gameStateMachine;

        public GameplayState(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            
        }

        public void EnterWithParam(string param)
        {
            
        }

        public void Exit()
        {
            
        }
    }
}