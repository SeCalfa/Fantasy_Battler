using CodeBase.Infrastructure.States;
using CodeBase.Logic.AttackDirection;
using CodeBase.Logic.OrcComponents;
using CodeBase.Services.Locator;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Logic.PlayerComponents
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
    public class Player : MonoBehaviour
    {
        private Transform spawnPoint;
        private GameObjectsLocator gameObjectsLocator;
        private GameStateMachine gameStateMachine;

        private NavMeshAgent agent;
        private Animator animator;

        private bool isMove = false;
        private Vector3 endPoint;
        private ArrowDirection orcDeffenceSide;
        private ArrowDirection playerAttackSide;

        public void Construct(Transform spawnPoint, GameObjectsLocator gameObjectsLocator, GameStateMachine gameStateMachine)
        {
            this.spawnPoint = spawnPoint;
            this.gameObjectsLocator = gameObjectsLocator;
            this.gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Movement();
        }

        public void StartMove(Vector3 endPoint)
        {
            this.endPoint = endPoint;
            isMove = true;
        }

        public void SetOrcDefSide(ArrowDirection side) =>
            orcDeffenceSide = side;

        public void SetPlayerAttackSide(ArrowDirection side) =>
            playerAttackSide = side;

        public void TakeDamage()
        {
            animator.SetTrigger("GetHit");

            print("Take damage");
        }

        public void ReturnToStartPos()
        {
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
        }

        private void Movement()
        {
            if (isMove)
            {
                agent.isStopped = false;
                agent.SetDestination(endPoint);
                animator.SetBool("IsRun", true);

                if (Vector3.Distance(transform.position, endPoint) < 0.1f)
                {
                    animator.SetTrigger("Attack");
                    agent.isStopped = true;
                    isMove = false;

                    StartCoroutine(Delay());
                }
            }
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(3f);

            gameStateMachine.Enter<PrepearToDefenceState>();
        }

        // For event on attack animation
        private void Attack()
        {
            animator.SetBool("IsRun", false);

            if (orcDeffenceSide == playerAttackSide)
                gameObjectsLocator.GetGameObjectByName(Constance.OrcName).GetComponent<Orc>().TakeDamage();
            else
                Debug.Log("Attack repulsed");
        }
    }
}