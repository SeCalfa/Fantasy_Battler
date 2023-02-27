using CodeBase.Logic.AttackDirection;
using CodeBase.Logic.Camera;
using CodeBase.Logic.Fence;
using CodeBase.Logic.OrcComponents;
using CodeBase.Logic.PlayerComponents;
using CodeBase.Logic.UI;
using CodeBase.Services;
using CodeBase.Services.Locator;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Infrastructure.States
{
    public class AttackingState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly RandomService randomService;
        private readonly GameObjectsLocator gameObjectsLocator;

        private ArrowDirection orcDeffenceSide;
        private ArrowDirection playerAttackSide;

        public AttackingState(GameStateMachine gameStateMachine, RandomService randomService, GameObjectsLocator gameObjectsLocator)
        {
            this.gameStateMachine = gameStateMachine;
            this.randomService = randomService;
            this.gameObjectsLocator = gameObjectsLocator;
        }

        public void Enter()
        {
            
        }

        public void EnterWithParam(string param)
        {
            orcDeffenceSide = randomService.GetRandomDirection();

            if (param == ArrowDirection.Left.ToString())
                playerAttackSide = ArrowDirection.Left;
            else
                playerAttackSide = ArrowDirection.Right;

            Debug.Log($"Orc deffence: {orcDeffenceSide}. Player attack: {playerAttackSide}");

            ActivateOrcFence();
            GamePanelOff();
            OrcSetPosition();
            PlayerRunForAttack();
            SidesConstruct();
            Camera.main.GetComponent<MoveCamera>().AttackOn();
        }

        public void Exit()
        {
            Camera.main.GetComponent<MoveCamera>().ReturnToStartPos();
            gameObjectsLocator.GetGameObjectByName(Constance.PlayerName).GetComponent<Player>().ReturnToStartPos();
            gameObjectsLocator.GetGameObjectByName(Constance.OrcName).GetComponent<Orc>().ReturnToStartPos();
            gameObjectsLocator.GetGameObjectByName(Constance.OrcFenceName).GetComponent<Fence>().LeftFencesOff();
            gameObjectsLocator.GetGameObjectByName(Constance.OrcFenceName).GetComponent<Fence>().RightFencesOff();
        }

        private void ActivateOrcFence()
        {
            GameObject orcFence = gameObjectsLocator.GetGameObjectByName(Constance.OrcFenceName);
            if (orcDeffenceSide == ArrowDirection.Left)
                orcFence.GetComponent<Fence>().LeftFencesOn();
            else
                orcFence.GetComponent<Fence>().RightFencesOn();
        }

        private void GamePanelOff()
        {
            gameObjectsLocator.GetGameObjectByName(Constance.CanvasName).GetComponent<MainCanvas>().TimerOff();
            gameObjectsLocator.GetGameObjectByName(Constance.CanvasName).GetComponent<MainCanvas>().GamePanelOff();
        }

        private void OrcSetPosition()
        {
            GameObject orc = gameObjectsLocator.GetGameObjectByName(Constance.OrcName);
            GameObject orcFence = gameObjectsLocator.GetGameObjectByName(Constance.OrcFenceName);

            if (orcDeffenceSide == ArrowDirection.Left)
                orc.transform.position = orcFence.GetComponent<Fence>().GetRightPosition;
            else
                orc.transform.position = orcFence.GetComponent<Fence>().GetLeftPosition;
        }

        private void PlayerRunForAttack()
        {
            GameObject orcFence = gameObjectsLocator.GetGameObjectByName(Constance.OrcFenceName);
            Vector3 target;

            if (playerAttackSide == ArrowDirection.Left)
                target = orcFence.GetComponent<Fence>().GetRightPositionForAttacker;
            else
                target = orcFence.GetComponent<Fence>().GetLeftPositionForAttacker;

            gameObjectsLocator.GetGameObjectByName(Constance.PlayerName).GetComponent<Player>().StartMove(target);
        }

        private void SidesConstruct()
        {
            gameObjectsLocator.GetGameObjectByName(Constance.PlayerName).GetComponent<Player>().SetPlayerAttackSide(playerAttackSide);
            gameObjectsLocator.GetGameObjectByName(Constance.PlayerName).GetComponent<Player>().SetOrcDefSide(orcDeffenceSide);
        }
    }
}