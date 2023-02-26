using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Logic.AttackDirection
{
    public class AttackDirectionCanvas : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] arrows;

        private ArrowCanvasType arrowCanvasType;
        private GameStateMachine gameStateMachine;

        public void Construct(ArrowCanvasType arrowCanvasType, GameStateMachine gameStateMachine)
        {
            this.arrowCanvasType = arrowCanvasType;
            this.gameStateMachine = gameStateMachine;
        }

        public void Attack()
        {
            print(arrowCanvasType + " | " + name);

            gameStateMachine.Enter<AttackingState>();
        }
    }
}