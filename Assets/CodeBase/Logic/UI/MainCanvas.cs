using CodeBase.Infrastructure.States;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CodeBase.Logic.UI
{
    public class MainCanvas : MonoBehaviour
    {
        [SerializeField]
        private GameObject tutorialPanel;
        [Space]
        [SerializeField]
        private GameObject gamePanel;
        [SerializeField]
        private Image timeSliderFront;
        [SerializeField]
        private TextMeshProUGUI timeText;

        private GameStateMachine gameStateMachine;

        private float maxTime = 5;
        private float currentTime = 5;
        private Coroutine timerCoroutine;

        public void Construct(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }

        public void TutorialPanelOn() =>
            tutorialPanel.SetActive(true);

        public void TutorialPanelOff() =>
            tutorialPanel.SetActive(false);

        public void GamePanelOn() =>
            gamePanel.SetActive(true);

        public void GamePanelOff() =>
            gamePanel.SetActive(false);

        public void TimerOn() =>
            timerCoroutine = StartCoroutine(Timer());

        public void TimerOff()
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }

        private IEnumerator Timer()
        {
            currentTime = maxTime;

            while (currentTime > 0)
            {
                yield return new WaitForSeconds(0.02f);
                currentTime -= 0.02f;

                timeSliderFront.fillAmount = currentTime / maxTime;
                timeText.text = currentTime.ToString("0.0s");
            }

            gameStateMachine.Enter<SkipTurnState>();
        }
    }
}