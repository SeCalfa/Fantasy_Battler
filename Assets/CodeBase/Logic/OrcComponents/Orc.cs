using UnityEngine;

namespace CodeBase.Logic.OrcComponents
{
    public class Orc : MonoBehaviour
    {
        private Transform spawnPoint;

        private Animator animator;

        public void Construct(Transform spawnPoint)
        {
            this.spawnPoint = spawnPoint;
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

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
    }
}