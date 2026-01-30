using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Campero.SkincareInYourFace.UI
{
    public class TitleScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _panel;
        [SerializeField] private Button _startButton;
        
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = GameManager.Instance;
            _startButton.onClick.AddListener(OnStartButtonClicked);
            _panel.gameObject.SetActive(true);
        }

        private void OnStartButtonClicked()
        {
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