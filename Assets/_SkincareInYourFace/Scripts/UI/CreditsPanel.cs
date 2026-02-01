using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Campero.SkincareInYourFace.UI
{
    public class CreditsPanel : MonoBehaviour
    {
        [SerializeField] private EventTrigger _hideButton;
        [SerializeField] private CanvasGroup _panel;
        
        private void Awake()
        {
            var entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback = new EventTrigger.TriggerEvent();
            entry.callback.AddListener(OnHideButtonClicked);
            _hideButton.triggers.Add(entry);
        }

        private void OnHideButtonClicked(BaseEventData _)
        {
            Hide();
        }

        public void Show()
        {
            _panel.gameObject.SetActive(true);
            _panel.DOFade(1, 0.5f);
        }
        
        private void Hide()
        {
            _panel.DOFade(0, 0.5f)
                .OnComplete(OnComplete);

            void OnComplete()
            {
                _panel.gameObject.SetActive(false);
            }
        }
    }
}