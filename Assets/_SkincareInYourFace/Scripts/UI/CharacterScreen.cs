using System;
using Campero.SkincareInYourFace.Audio;
using Campero.SkincareInYourFace.Characters;
using Campero.SkincareInYourFace.Environment;
using Campero.SkincareInYourFace.Interactions;
using DG.Tweening;
using I2.Loc;
using MiguelGameDev;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Campero.SkincareInYourFace.UI
{
    public class CharacterScreen : SingletonBehaviour<CharacterScreen>
    {
        [SerializeField] private RectTransform _characterPanel;
        [SerializeField] private RectTransform _panelTransform;
        [SerializeField] private Image _background;
        [SerializeField] private DialoguePanel _dialoguePanel;
        [SerializeField] private EventTrigger _hideButton;
        [SerializeField] private Button _talkButton;
        [SerializeField] private Button _accuseButton;
        [SerializeField] private RectTransform _accusedPanel;
        [SerializeField] private AccusationPanel _accusationPanel;

        [SerializeField] private Image _avatarImage;
        [SerializeField] private Localize _characterNameText;
        
        private CharacterStates _characterStates;
        private Character _character;
        
        protected override void Awake()
        {
            base.Awake();
            _characterStates = CharacterStates.Instance;
            
            var entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback = new EventTrigger.TriggerEvent();
            entry.callback.AddListener(OnButtonHide);
            _hideButton.triggers.Add(entry);
            
            _accuseButton.onClick.AddListener(OnAccuseButtonClicked);
            _talkButton.onClick.AddListener(OnTalkButtonClicked);
            
            _background.SetAlpha(0);
            _panelTransform.SetAnchoredPositionX(_panelTransform.sizeDelta.x);
            
            _characterPanel.gameObject.SetActive(false);
            _accusedPanel.gameObject.SetActive(false);
            _accuseButton.gameObject.SetActive(true);
        }

        private void OnTalkButtonClicked()
        {
            AudioPlayer.Instance.PlayTalkSound();
            _accuseButton.gameObject.SetActive(false);
            _accusedPanel.gameObject.SetActive(false);
            _talkButton.gameObject.SetActive(false);
            _dialoguePanel.Show();
        }

        private void OnAccuseButtonClicked()
        {
            AudioPlayer.Instance.PlayAccuseSound();
            ShowAccusationPanel();
        }

        private void OnButtonHide(BaseEventData _)
        {
            AudioPlayer.Instance.PlayCloseUiSound();
            Hide(
                Terminate);
        }
        
        public void Terminate()
        {
            CameraMovement.Instance.CanMove = true;
            PointerController.Instance.IsEnabled = true;
            _characterPanel.gameObject.SetActive(false);
        }

        [Sirenix.OdinInspector.Button]
        public void Show(Character character)
        {
            _character = character;
            
            CameraMovement.Instance.CanMove = false;
            PointerController.Instance.IsEnabled = false;
            _talkButton.gameObject.SetActive(true);
            SetAccusation();

            _avatarImage.sprite = _character.Model.CharacterAvatar;
            _characterNameText.SetTerm(_character.Model.NameTerm);

            _dialoguePanel.Clear();
            _characterPanel.gameObject.SetActive(true);
            _dialoguePanel.Setup(this, _character);
            _accusationPanel.Setup(this, 
                _avatarImage.GetComponent<RectTransform>(), _character);
            
            Show();
        }

        public void Show()
        {
            AudioPlayer.Instance.PlayOpenUiSound();
            
            _background.DOFade(0.8f, 0.2f);
            _panelTransform.DOAnchorPosX(0, 0.2f);
        }

        private void SetAccusation()
        {
            if (_characterStates.IsAccused(_character))
            {
                _accuseButton.gameObject.SetActive(false);
                _accusedPanel.gameObject.SetActive(true);
            }
            else
            {
                _accuseButton.gameObject.SetActive(true);
                _accusedPanel.gameObject.SetActive(false);
            }
        }

        public void Hide(Action callback)
        {
            _background.DOFade(0f, 0.2f)
                .OnComplete(OnComplete);
            
            _panelTransform.DOAnchorPosX(_panelTransform.sizeDelta.x, 0.2f);
            
            void OnComplete()
            {
                callback.Invoke();
            }
        }

        public void BackFromDialoguePanel()
        {
            SetAccusation();
            _talkButton.gameObject.SetActive(true);
        }
        
        private void ShowAccusationPanel()
        {
            _accusationPanel.PrepareShow();
            Hide(_accusationPanel.Show);
        }
        
        public void BackFromAccusationPanel()
        {
            Show();
        }
    }
}