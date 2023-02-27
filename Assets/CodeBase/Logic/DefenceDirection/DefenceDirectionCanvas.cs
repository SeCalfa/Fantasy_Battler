using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Logic.DefenceDirection
{
    public class DefenceDirectionCanvas : MonoBehaviour
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
            gameStateMachine.Enter<DefencingState>(arrowCanvasType.ToString());
        }
    }
}