using CodeBase.Logic.AttackDirection;
using CodeBase.Logic.UI;
using CodeBase.Services;
using CodeBase.Services.Locator;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class PrepearToAttackState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly GameFactory gameFactory;
        private readonly GameObjectsLocator gameObjectsLocator;

        private List<GameObject> arrows;

        public PrepearToAttackState(GameStateMachine gameStateMachine, GameFactory gameFactory, GameObjectsLocator gameObjectsLocator)
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
        }

        private List<GameObject> SpawnArrows()
        {
            GameObject spawnPointLeft = GameObject.FindGameObjectWithTag(Constance.ArrowsSpawnPointLeftTag);
            GameObject spawnPointRight = GameObject.FindGameObjectWithTag(Constance.ArrowsSpawnPointRightTag);

            GameObject left = gameFactory.CreateArrowCanvas(spawnPointLeft.GetComponent<RectTransform>());
            GameObject right = gameFactory.CreateArrowCanvas(spawnPointRight.GetComponent<RectTransform>());

            left.GetComponent<AttackDirectionCanvas>().Construct(ArrowDirection.Left, gameStateMachine);
            right.GetComponent<AttackDirectionCanvas>().Construct(ArrowDirection.Right, gameStateMachine);

            return new List<GameObject>() { left, right };
        }
    }
}