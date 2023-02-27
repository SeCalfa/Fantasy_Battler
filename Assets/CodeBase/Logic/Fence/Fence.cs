using UnityEngine;

namespace CodeBase.Logic.Fence
{
    public class Fence : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] rightFences;
        [SerializeField]
        private GameObject[] leftFences;
        [Space]
        [SerializeField]
        private Transform rightPosition;
        [SerializeField]
        private Transform leftPosition;
        [SerializeField]
        private Transform rightPositionForAttacker;
        [SerializeField]
        private Transform leftPositionForAttacker;

        public void RightFencesOn()
        {
            foreach (var fence in rightFences)
                fence.SetActive(true);
        }

        public void LeftFencesOn()
        {
            foreach (var fence in leftFences)
                fence.SetActive(true);
        }

        public void RightFencesOff()
        {
            foreach (var fence in rightFences)
                fence.SetActive(false);
        }

        public void LeftFencesOff()
        {
            foreach (var fence in leftFences)
                fence.SetActive(false);
        }

        public Vector3 GetRightPosition =>
            rightPosition.position;

        public Vector3 GetLeftPosition =>
            leftPosition.position;

        public Vector3 GetRightPositionForAttacker =>
           rightPositionForAttacker.position;

        public Vector3 GetLeftPositionForAttacker =>
            leftPositionForAttacker.position;
    }
}