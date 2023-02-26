using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Logic.AttackDirection
{
    public class ArrowButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private AttackDirectionCanvas attackDirectionCanvas;

        public void OnPointerClick(PointerEventData eventData)
        {
            attackDirectionCanvas.Attack();
        }
    }
}