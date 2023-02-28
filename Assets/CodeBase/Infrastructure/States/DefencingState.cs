using CodeBase.Logic.MainCamera;
using CodeBase.Services.Locator;
using CodeBase.Services;
using UnityEngine;
using CodeBase.Logic;
using CodeBase.Logic.Fence;
using CodeBase.Logic.UI;
using CodeBase.Logic.PlayerComponents;
using CodeBase.Logic.OrcComponents;

namespace CodeBase.Infrastructure.States
{
    public class DefencingState : IState
    {
        private readonly RandomService randomService;
        private readonly GameObjectsLocator gameObjectsLocator;

        private ArrowDirection playerDeffenceSide;
        private ArrowDirection orcAttackSide;

        public DefencingState(RandomService randomService, GameObjectsLocator gameObjectsLocator)
        {
            this.randomService = randomService;
            this.gameObjectsLocator = gameObjectsLocator;
        }

        public void Enter()
        {
            
        }

        public void EnterWithParam(string param)
        {
            orcAttackSide = randomService.GetRandomDirection();

            if (param == ArrowDirection.Left.ToString())
                playerDeffenceSide = ArrowDirection.Left;
            else
                playerDeffenceSide = ArrowDirection.Right;

            Debug.Log($"Orc attack: {orcAttackSide}. Player deffence: {playerDeffenceSide}");

            ActivatePlayerFence();
            PlayerSetPosition();
            OrcRunForAttack();
            SidesConstruct();
            Camera.main.GetComponent<MoveCamera>().DefenceOn();
        }

        public void Exit()
        {
            Camera.main.GetComponent<MoveCamera>().ReturnToStartPos();
            gameObjectsLocator.GetGameObjectByName(Constance.PlayerName).GetComponent<Player>().ReturnToStartPos();
            gameObjectsLocator.GetGameObjectByName(Constance.OrcName).GetComponent<Orc>().ReturnToStartPos();
            gameObjectsLocator.GetGameObjectByName(Constance.PlayerFenceName).GetComponent<Fence>().LeftFencesOff();
            gameObjectsLocator.GetGameObjectByName(Constance.PlayerFenceName).GetComponent<Fence>().RightFencesOff();
        }

        private void ActivatePlayerFence()
        {
            GameObject orcFence = gameObjectsLocator.GetGameObjectByName(Constance.PlayerFenceName);
            if (playerDeffenceSide == ArrowDirection.Left)
                orcFence.GetComponent<Fence>().LeftFencesOn();
            else
                orcFence.GetComponent<Fence>().RightFencesOn();
        }

        private void PlayerSetPosition()
        {
            GameObject player = gameObjectsLocator.GetGameObjectByName(Constance.PlayerName);
            GameObject playerFence = gameObjectsLocator.GetGameObjectByName(Constance.PlayerFenceName);

            if (playerDeffenceSide == ArrowDirection.Left)
                player.transform.position = playerFence.GetComponent<Fence>().GetRightPosition;
            else
                player.transform.position = playerFence.GetComponent<Fence>().GetLeftPosition;
        }

        private void OrcRunForAttack()
        {
            GameObject playerFence = gameObjectsLocator.GetGameObjectByName(Constance.PlayerFenceName);
            Vector3 target;

            if (orcAttackSide == ArrowDirection.Left)
                target = playerFence.GetComponent<Fence>().GetRightPositionForAttacker;
            else
                target = playerFence.GetComponent<Fence>().GetLeftPositionForAttacker;

            gameObjectsLocator.GetGameObjectByName(Constance.OrcName).GetComponent<Orc>().StartMove(target);
        }

        private void SidesConstruct()
        {
            gameObjectsLocator.GetGameObjectByName(Constance.OrcName).GetComponent<Orc>().SetOrcAttackSide(orcAttackSide);
            gameObjectsLocator.GetGameObjectByName(Constance.OrcName).GetComponent<Orc>().SetPlayerDeffenceSide(playerDeffenceSide);
        }
    }
}