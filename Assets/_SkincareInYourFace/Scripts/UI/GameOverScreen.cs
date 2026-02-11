using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Campero.SkincareInYourFace.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _panel;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _quitButton;
        
        private void Awake()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
#if UNITY_WEBGL
            _quitButton.gameObject.SetActive(false);
#else
            _quitButton.onClick.AddListener(Application.Quit);
#endif
            _panel.gameObject.SetActive(false);
        }

        public void Show()
        {
            _panel.gameObject.SetActive(true);
            _panel.DOFade(1, 1f);
        }
        
        private void OnStartButtonClicked()
        {
            SceneManager.LoadScene(0);
        }
    }
}