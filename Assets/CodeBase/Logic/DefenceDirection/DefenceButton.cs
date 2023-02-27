using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Logic.DefenceDirection
{
    public class DefenceButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private DefenceDirectionCanvas defenceDirectionCanvas;

        public void OnPointerClick(PointerEventData eventData)
        {
            defenceDirectionCanvas.Attack();
        }
    }
}