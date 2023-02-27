using CodeBase.Logic.OrcComponents;
using CodeBase.Logic.PlayerComponents;
using CodeBase.Logic.UI;
using CodeBase.Services;
using CodeBase.Services.Locator;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly SceneLoader sceneLoader;
        private readonly GameFactory gameFactory;
        private readonly GameObjectsLocator gameObjectsLocator;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, GameFactory gameFactory, GameObjectsLocator gameObjectsLocator)
        {
            this.gameStateMachine = gameStateMachine;
            this.sceneLoader = sceneLoader;
            this.gameFactory = gameFactory;
            this.gameObjectsLocator = gameObjectsLocator;
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
            gameObjectsLocator.RegisterGameObject(Constance.PlayerName, SpawnPlayer());
            gameObjectsLocator.RegisterGameObject(Constance.OrcName, SpawnOrc());
            gameObjectsLocator.RegisterGameObject(Constance.PlayerFenceName, SpawnPlayerFence());
            gameObjectsLocator.RegisterGameObject(Constance.OrcFenceName, SpawnOrcFence());
            gameObjectsLocator.RegisterGameObject(Constance.CanvasName, SpawnCanvas());
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

        private GameObject SpawnPlayer()
        {
            GameObject spawnPoint = GameObject.FindGameObjectWithTag(Constance.PlayerSpawnPointTag);
            GameObject player = gameFactory.CreatePlayer(spawnPoint.transform);
            player.GetComponent<Player>().Construct(spawnPoint.transform, gameObjectsLocator, gameStateMachine);

            return player;
        }

        private GameObject SpawnOrc()
        {
            GameObject spawnPoint = GameObject.FindGameObjectWithTag(Constance.OrcSpawnPointTag);
            GameObject orc = gameFactory.CreateOrc(spawnPoint.transform);
            orc.GetComponent<Orc>().Construct(spawnPoint.transform);

            return orc;
        }

        private GameObject SpawnPlayerFence()
        {
            GameObject spawnPoint = GameObject.FindGameObjectWithTag(Constance.PlayerFenceTag);
            return gameFactory.CreatePlayerFence(spawnPoint.transform);
        }

        private GameObject SpawnOrcFence()
        {
            GameObject spawnPoint = GameObject.FindGameObjectWithTag(Constance.OrcFenceTag);
            return gameFactory.CreateOrcFence(spawnPoint.transform);
        }

        private GameObject SpawnCanvas()
        {
            GameObject canvas = gameFactory.CreateCanvas();
            canvas.GetComponent<MainCanvas>().Construct(gameStateMachine);

            return canvas;
        }
    }
}
