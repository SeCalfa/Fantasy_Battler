using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly SceneLoader sceneLoader;
        private readonly GameFactory gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, GameFactory gameFactory)
        {
            this.gameStateMachine = gameStateMachine;
            this.sceneLoader = sceneLoader;
            this.gameFactory = gameFactory;
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
            SpawnPlayer();
            SpawnOrc();
        }

        private void OnLoaded()
        {
            if (!PlayerPrefs.HasKey("FirstOpen"))
            {
                PlayerPrefs.SetInt("FirstOpen", 1);
                gameStateMachine.Enter<TutorialState>();
            }
            else
                gameStateMachine.Enter<PrepearToAttackState>();
        }

        private void SpawnPlayer()
        {
            GameObject spawnPoint = GameObject.FindGameObjectWithTag(Constance.PlayerSpawnPointTag);
            gameFactory.CreatePlayer(spawnPoint.transform);
        }

        private void SpawnOrc()
        {
            GameObject spawnPoint = GameObject.FindGameObjectWithTag(Constance.OrcSpawnPointTag);
            gameFactory.CreateOrc(spawnPoint.transform);
        }
    }
}
