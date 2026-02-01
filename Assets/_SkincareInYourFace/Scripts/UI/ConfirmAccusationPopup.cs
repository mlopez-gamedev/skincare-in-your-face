using Cysharp.Threading.Tasks;
using DG.Tweening;
using I2.Loc;
using MiguelGameDev;
using UnityEngine;
using UnityEngine.UI;

namespace Campero.SkincareInYourFace.UI
{
    public class ConfirmAccusationPopup : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private RectTransform _panel;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _cancelButton;
        [SerializeField] private Localize _messageText;
        [SerializeField] private LocalizationParamsManager _localizationParams;
        [SerializeField, TermsPopup] private string[] _confirmMessages;
        
        UniTaskCompletionSource<bool> _confirmCompletionSource;
        public decimal MaxMessages => _confirmMessages.Length;

        private void Awake()
        {
            _background.SetAlpha(0);
            _panel.SetScale(0);
            _background.gameObject.SetActive(false);
            
            _confirmButton.onClick.AddListener(Confirm);
            _cancelButton.onClick.AddListener(Cancel);
        }
        
        public UniTask<bool> ConfirmAccusation(string characterName, string itemName, int messageIndex)
        {
            _confirmCompletionSource = new UniTaskCompletionSource<bool>();
            _localizationParams.SetParameterValue("Character", characterName);
            _localizationParams.SetParameterValue("Item", itemName);
            _messageText.SetTerm(_confirmMessages[messageIndex]);

            Show();
            
            return _confirmCompletionSource.Task;
        }

        private void Show()
        {
            _background.gameObject.SetActive(true);
            DOTween.Sequence()
                .Append(_background.DOFade(0.8f, 0.2f))
                .Join(_panel.DOScale(1f, 0.2f).SetEase(Ease.OutBack));
        }

        private void Confirm()
        {
            Hide(true);
        }

        private void Cancel()
        {
            Hide(false);
        }
        
        private void Hide(bool result)
        {
            DOTween.Sequence()
                .Append(_background.DOFade(0f, 0.2f))
                .Join(_panel.DOScale(0, 0.2f).SetEase(Ease.OutBack))
                .OnComplete(OnComplete);

            void OnComplete()
            {
                _confirmCompletionSource.TrySetResult(result);
            }
        }
    }
}