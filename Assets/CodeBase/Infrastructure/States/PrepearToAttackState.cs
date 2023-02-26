using CodeBase.Logic.AttackDirection;
using CodeBase.Services;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class PrepearToAttackState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly GameFactory gameFactory;

        private List<GameObject> arrows;

        public PrepearToAttackState(GameStateMachine gameStateMachine, GameFactory gameFactory)
        {
            this.gameStateMachine = gameStateMachine;
            this.gameFactory = gameFactory;
        }

        public void Enter()
        {
            arrows = SpawnArrows();
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

            left.GetComponent<AttackDirectionCanvas>().Construct(ArrowCanvasType.Left, gameStateMachine);
            right.GetComponent<AttackDirectionCanvas>().Construct(ArrowCanvasType.Right, gameStateMachine);

            return new List<GameObject>() { left, right };
        }
    }
}