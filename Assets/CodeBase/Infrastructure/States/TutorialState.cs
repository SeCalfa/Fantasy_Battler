namespace CodeBase.Infrastructure.States
{
    public class TutorialState : IState
    {
        private readonly GameStateMachine gameStateMachine;

        public TutorialState(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            gameStateMachine.Enter<PrepearToAttackState>();
        }

        public void EnterWithParam(string param)
        {
            
        }

        public void Exit()
        {
            
        }
    }
}