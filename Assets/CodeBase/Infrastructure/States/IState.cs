namespace CodeBase.Infrastructure.States
{
    public interface IState
    {
        void Enter();
        void EnterWithParam(string param);
        void Exit();
    }
}
