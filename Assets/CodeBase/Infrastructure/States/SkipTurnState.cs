using CodeBase.Logic.Fence;
using CodeBase.Logic.MainCamera;
using CodeBase.Logic.OrcComponents;
using CodeBase.Logic.PlayerComponents;
using CodeBase.Services.Locator;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class SkipTurnState : IState
    {
        private readonly GameObjectsLocator gameObjectsLocator;

        public SkipTurnState(GameObjectsLocator gameObjectsLocator)
        {
            this.gameObjectsLocator = gameObjectsLocator;
        }

        public void Enter()
        {
            OrcRunForAttack();
            Camera.main.GetComponent<MoveCamera>().DefenceOn();
        }

        public void EnterWithParam(string param)
        {
            
        }

        public void Exit()
        {
            Camera.main.GetComponent<MoveCamera>().ReturnToStartPos();
            gameObjectsLocator.GetGameObjectByName(Constance.OrcName).GetComponent<Orc>().ReturnToStartPos();
        }

        private void OrcRunForAttack()
        {
            GameObject playerFence = gameObjectsLocator.GetGameObjectByName(Constance.PlayerFenceName);
            Vector3 target;

            target = playerFence.GetComponent<Fence>().GetMiddlePositionForAttacker;

            gameObjectsLocator.GetGameObjectByName(Constance.OrcName).GetComponent<Orc>().StartMove(target);
        }
    }
}