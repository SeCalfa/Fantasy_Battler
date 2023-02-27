using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Logic.AttackDirection
{
    public class AttackDirectionCanvas : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] arrows;

        private ArrowDirection arrowCanvasType;
        private GameStateMachine gameStateMachine;

        public void Construct(ArrowDirection arrowCanvasType, GameStateMachine gameStateMachine)
        {
            this.arrowCanvasType = arrowCanvasType;
            this.gameStateMachine = gameStateMachine;
        }

        public void Attack()
        {
            gameStateMachine.Enter<AttackingState>(arrowCanvasType.ToString());
        }
    }
}