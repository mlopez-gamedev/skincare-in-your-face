using System.Threading.Tasks;
using Campero.SkincareInYourFace.Audio;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using MiguelGameDev;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Campero.SkincareInYourFace.UI
{
    public class Intro : MonoBehaviour
    {
        [SerializeField] private VideoPlayer _videoPlayer;
        [SerializeField] private RawImage _videoImage;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button _continueButton;
        [SerializeField] private TMP_Text _introText;

        private UniTaskCompletionSource _introScreenTcs;
        
        private void Awake()
        {
            _introPlayed = false;
            _continueButton.interactable = false;
            _canvasGroup.gameObject.SetActive(true);
            _continueButton.gameObject.SetActive(false);
            _continueButton.onClick.AddListener(Continue);
        }

        private bool _introPlayed;
        
        public async UniTask Play()
        {
            EnableContinueButton();
            await PlayIntro();
            _introPlayed = true;
            await ShowIntroScreen();
            DisableContinueButton();
            await Hide();
        }

        private async UniTask Hide()
        {
            await _canvasGroup.DOFade(0, 0.5f).AsyncWaitForCompletion();
            _introText.gameObject.SetActive(false);
            _continueButton.gameObject.SetActive(false);
            _canvasGroup.gameObject.SetActive(false);
        }

        private UniTask ShowIntroScreen()
        {
            _introScreenTcs = new UniTaskCompletionSource();
            _introText.SetAlpha(0);
            _introText.gameObject.SetActive(true);
            _introText.DOFade(1f, 1f);
            return _introScreenTcs.Task;
        }

        private void EnableContinueButton()
        {
            _continueButton.gameObject.SetActive(true);
            _continueButton.targetGraphic.DOFade(1f, 0.5f).OnComplete(() =>
            {
                _continueButton.interactable = true;
            });
        }
        
        private void DisableContinueButton()
        {
            _continueButton.interactable = false;
            //_continueButton.targetGraphic.DOFade(0f, 0.5f);
        }
        
        private async UniTask PlayIntro()
        {
            _canvasGroup.gameObject.SetActive(true);
            _videoPlayer.gameObject.SetActive(true);
            _canvasGroup.DOFade(1f, 0.2f);
            await PlayVideoIntro();
            //await _canvasGroup.DOFade(0, 0.5f).AsyncWaitForCompletion();
            _videoPlayer.gameObject.SetActive(false);
        }

        private UniTask PlayVideoIntro()
        {
            var introTaskCompletionSource = new UniTaskCompletionSource();
            
            _videoPlayer.loopPointReached += OnSeekCompleted;
            _videoPlayer.Play();

            return introTaskCompletionSource.Task;

            void OnSeekCompleted(VideoPlayer _)
            {
                Debug.Log("OnSeekCompleted");
                introTaskCompletionSource.TrySetResult();
            }
        }
        
        private void Continue()
        {
            if (_introPlayed)
            {
                AudioPlayer.Instance.PlayClickUiSound();
                HideIntroScreen();
            }
            else if (_videoPlayer.time < _videoPlayer.clip.length)
            {
                AudioPlayer.Instance.PlayClickUiSound();
                _videoImage.DOFade(0, 0.5f).OnComplete(() =>
                {
                    _videoPlayer.time = _videoPlayer.clip.length;
                });
            }
        }

        private void HideIntroScreen()
        {
            _introScreenTcs.TrySetResult();
        }
    }
}