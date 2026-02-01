using Campero.SkincareInYourFace.Audio;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Campero.SkincareInYourFace.UI
{
    public class TitleScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _panel;
        [SerializeField] private CreditsPanel _creditsPanel;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _creditsButton;
        [SerializeField] private Button _quitButton;
        
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = GameManager.Instance;
            _startButton.onClick.AddListener(OnStartButtonClicked);
            _creditsButton.onClick.AddListener(OnCreditsButtonClicked);
            _quitButton.onClick.AddListener(Application.Quit);
            _panel.gameObject.SetActive(true);
        }

        private void OnCreditsButtonClicked()
        {
            AudioPlayer.Instance.PlayClickUiSound();
            _creditsPanel.Show();
        }

        private void OnStartButtonClicked()
        {
            AudioPlayer.Instance.PlayClickUiSound();
            HideAndStartNewGame();
        }

        private void HideAndStartNewGame()
        {
            _panel.interactable = false;
            _panel.DOFade(0, 1f)
                .OnComplete(OnHideComplete);

            void OnHideComplete()
            {
                _panel.gameObject.SetActive(false);
                _gameManager.StartNewGame();
            }
        }
    }
}