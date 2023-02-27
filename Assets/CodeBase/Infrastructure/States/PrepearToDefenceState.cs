using CodeBase.Logic;
using CodeBase.Services;
using System.Collections.Generic;
using UnityEngine;
using CodeBase.Logic.DefenceDirection;
using CodeBase.Services.Locator;
using CodeBase.Logic.UI;

namespace CodeBase.Infrastructure.States
{
    public class PrepearToDefenceState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly GameFactory gameFactory;
        private readonly GameObjectsLocator gameObjectsLocator;

        private List<GameObject> arrows;

        public PrepearToDefenceState(GameStateMachine gameStateMachine, GameFactory gameFactory, GameObjectsLocator gameObjectsLocator)
        {
            this.gameStateMachine = gameStateMachine;
            this.gameFactory = gameFactory;
            this.gameObjectsLocator = gameObjectsLocator;
        }

        public void Enter()
        {
            arrows = SpawnArrows();

            GameObject mainCanvas = gameObjectsLocator.GetGameObjectByName(Constance.CanvasName);
            mainCanvas.GetComponent<MainCanvas>().GamePanelOn();
            mainCanvas.GetComponent<MainCanvas>().TimerOn();
        }

        public void EnterWithParam(string param)
        {
            
        }

        public void Exit()
        {
            foreach (GameObject arrow in arrows)
                Object.Destroy(arrow);

            arrows.Clear();
            GamePanelOff();
        }

        private List<GameObject> SpawnArrows()
        {
            GameObject spawnPointLeft = GameObject.FindGameObjectWithTag(Constance.ArrowsSpawnPointLeftTag);
            GameObject spawnPointRight = GameObject.FindGameObjectWithTag(Constance.ArrowsSpawnPointRightTag);

            GameObject left = gameFactory.CreateArrowDefenceCanvas(spawnPointLeft.GetComponent<RectTransform>());
            GameObject right = gameFactory.CreateArrowDefenceCanvas(spawnPointRight.GetComponent<RectTransform>());

            left.GetComponent<DefenceDirectionCanvas>().Construct(ArrowDirection.Left, gameStateMachine);
            right.GetComponent<DefenceDirectionCanvas>().Construct(ArrowDirection.Right, gameStateMachine);

            return new List<GameObject>() { left, right };
        }

        private void GamePanelOff()
        {
            gameObjectsLocator.GetGameObjectByName(Constance.CanvasName).GetComponent<MainCanvas>().TimerOff();
            gameObjectsLocator.GetGameObjectByName(Constance.CanvasName).GetComponent<MainCanvas>().GamePanelOff();
        }
    }
}