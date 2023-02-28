using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace CodeBase.Logic.UI
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField]
        private MainCanvas mainCanvas;
        [Space]
        [SerializeField]
        private TutorialPage[] tutorialPages;
        [Space]
        [SerializeField]
        private Image picture;
        [SerializeField]
        private TextMeshProUGUI text;
        [SerializeField]
        private Button nextButton;

        private int currentPage = 0;

        private void Awake()
        {
            nextButton.onClick.AddListener(Next);
        }

        private void Next()
        {
            currentPage += 1;

            if(currentPage == 3)
            {
                mainCanvas.TutorialEnd();
                return;
            }

            picture.sprite = tutorialPages[currentPage].sprite;
            text.text = tutorialPages[currentPage].text;
        }
    }

    [Serializable]
    public class TutorialPage
    {
        public Sprite sprite;
        public string text;
    }
}