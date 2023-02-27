using UnityEngine;

namespace CodeBase.Logic.Camera
{
    public class MoveCamera : MonoBehaviour
    {
        [SerializeField]
        private Transform cameraStartPoint;
        [Space]
        [SerializeField]
        private Transform attackStartPoint;
        [SerializeField]
        private Transform attackEndPoint;

        private float alpha = 0;
        private bool isAttackCameraMove = false;

        private void LateUpdate()
        {
            AttackCameraMove();
        }

        public void AttackOn() => isAttackCameraMove = true;

        public void ReturnToStartPos()
        {
            transform.position = cameraStartPoint.position;
            transform.rotation = cameraStartPoint.rotation;
        }

        private void AttackCameraMove()
        {
            if (isAttackCameraMove)
            {
                alpha = Mathf.Clamp01(alpha + Time.deltaTime / 2);
                transform.position = Vector3.Lerp(attackStartPoint.position, attackEndPoint.position, alpha);
                transform.rotation = Quaternion.Lerp(attackStartPoint.rotation, attackEndPoint.rotation, alpha);

                if(alpha == 1)
                {
                    isAttackCameraMove = false;
                    alpha = 0;
                }
            }
        }
    }
}