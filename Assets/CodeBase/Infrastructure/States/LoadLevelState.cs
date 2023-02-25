using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly SceneLoader sceneLoader;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            this.gameStateMachine = gameStateMachine;
            this.sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            
        }

        public void EnterWithParam(string param)
        {
            sceneLoader.Load(param, OnLoaded);
        }

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            if (!PlayerPrefs.HasKey("FirstOpen"))
            {
                PlayerPrefs.SetInt("FirstOpen", 1);
                gameStateMachine.Enter<TutorialState>();
            }
            else
                gameStateMachine.Enter<GameplayState>();
        }
    }
}
