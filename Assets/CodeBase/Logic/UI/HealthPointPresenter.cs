using UnityEngine;
using TMPro;

namespace CodeBase.Logic.UI
{
    public class HealthPointPresenter : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI HpText;

        private void Update()
        {
            Quaternion rotation = Camera.main.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
        }

        public void UpdateHp(int currentHp)
        {
            HpText.text = $"x{currentHp}";
        }
    }
}