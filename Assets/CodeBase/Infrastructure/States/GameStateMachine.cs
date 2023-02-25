using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IState> states;
        private IState activeState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader),
                [typeof(TutorialState)] = new TutorialState(this),
                [typeof(GameplayState)] = new GameplayState(this)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState>(string payload) where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.EnterWithParam(payload);
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            activeState?.Exit();

            TState state = GetState<TState>();
            activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IState =>
            states[typeof(TState)] as TState;
    }
}
