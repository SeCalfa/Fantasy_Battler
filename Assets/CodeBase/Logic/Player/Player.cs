using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Logic.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Player : MonoBehaviour
    {
        private NavMeshAgent agent;

        private bool isMove = false;
        private Vector3 endPoint;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (isMove)
            {
                agent.destination = endPoint;
            }
        }

        public void StartMove(Vector3 endPoint)
        {
            this.endPoint = endPoint;
            isMove = true;
        }
    }
}