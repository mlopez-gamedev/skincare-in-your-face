using System;
using Campero.SkincareInYourFace.Characters;
using Campero.SkincareInYourFace.Items;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using MiguelGameDev;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Campero.SkincareInYourFace.UI
{
    public class AccusationPanel : MonoBehaviour
    {
        [SerializeField] private EventTrigger _backButton;
        [SerializeField] private ConfirmAccusationPopup _confirmAccusationPopup;

        [SerializeField] private RectTransform _itemSelectorContainer;
        [SerializeField] private ItemSelector _itemSelectorPrefab;
        
        private CharacterScreen _characterScreen;
        private RectTransform _characterAvatar;
        private Character _character;

        private Transform _characterOriginParent;
        private Vector3 _characterOriginPosition;
        
        private int _accusationCount;
        
        private void Awake()
        {
            var entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback = new EventTrigger.TriggerEvent();
            entry.callback.AddListener(OnBackButtonCliked);
            _backButton.triggers.Add(entry);
            
            _backButton.enabled = false;
        }

        public void Setup(CharacterScreen characterScreen, RectTransform characterAvatar, Character character)
        {
            _characterScreen  = characterScreen;
            _characterAvatar = characterAvatar;
        }

        private void OnBackButtonCliked(BaseEventData _)
        {
            Hide(Back);
        }

        public void PrepareShow()
        {
            _characterOriginParent = transform.parent;
            _characterOriginPosition = _characterAvatar.position;
            _characterAvatar.SetParent(transform, true);
        }
        
        public void Show()
        {
            var viewedItems = ItemStates.Instance.GetViewedItems();
            if (viewedItems.Length == 0)
            {
                DOTween.Sequence()
                    .Append(_characterAvatar.DOAnchorPos(Vector2.zero, 0.5f))
                    .Join(_characterAvatar.DOScale(0.75f, 0.5f))
                    .OnComplete(OnComplete);
                return;
            }
            var anglePerItem = 360f / viewedItems.Length;

            for (int i = 0; i < viewedItems.Length; ++i)
            {
                var itemSelector = Instantiate(_itemSelectorPrefab, _itemSelectorContainer);
                itemSelector.transform.rotation = Quaternion.Euler(0f, 0f, anglePerItem * i);
                itemSelector.Init(viewedItems[i]);
            }
            
            _itemSelectorContainer.SetScale(10f);
            
            DOTween.Sequence()
                .Append(_characterAvatar.DOAnchorPos(Vector2.zero, 0.5f))
                .Join(_characterAvatar.DOScale(0.75f, 0.5f))
                .Append(_itemSelectorContainer.DORotate(new Vector3(0f, 0f, 360f), 1f).SetEase(Ease.InOutQuad))
                .Append(_itemSelectorContainer.DOScale(1f, 1f).SetEase(Ease.Flash))
                .OnComplete(OnComplete);

            // TODO: show items
            OnComplete();
            
            void OnComplete()
            {
                _backButton.enabled = true;
            }
        }
        
        private void Hide(Action callback)
        {
            _backButton.enabled = false;

            // TODO: hide items
            OnComplete();
            
            void OnComplete()
            {
                _itemSelectorContainer.DestroyAllChildren();
                callback?.Invoke();    
            }
        }
        
        private void Back()
        {
            _characterAvatar.SetParent(_characterOriginParent, true);
            DOTween.Sequence()
                .Append(_characterAvatar.DOMove(_characterOriginPosition, 0.5f))
                .Join(_characterAvatar.DOScale(1f, 0.5f))
                .OnComplete(OnComplete);
            
            _characterScreen.BackFromAccusationPanel();

            void OnComplete()
            {
                _characterAvatar.anchoredPosition = Vector2.zero;
            }
        }

        private async void StartAccusationFlow(ItemModel item)
        {
            ++_accusationCount;
            var accusationAmount = Math.Min(_accusationCount, _confirmAccusationPopup.MaxMessages);
            for (int i = 0; i < accusationAmount; ++i)
            {
                if (!await ConfirmAccusation(item, i))
                {
                    return;
                }
            }

            AccuseCharacter(item);
        }

        private void AccuseCharacter(ItemModel item)
        {
            CharacterStates.Instance.AccuseCharacter(_character, item);
        }

        private UniTask<bool> ConfirmAccusation(ItemModel item, int messageIndex)
        {
            return _confirmAccusationPopup.ConfirmAccusation(
                I2.Loc.LocalizationManager.GetTranslation(_character.Model.NameTerm),
                I2.Loc.LocalizationManager.GetTranslation(item.NameTerm),
                messageIndex);
        }
    }
}