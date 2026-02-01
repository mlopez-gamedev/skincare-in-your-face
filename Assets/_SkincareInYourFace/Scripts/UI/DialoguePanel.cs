using System;
using System.Collections;
using Campero.SkincareInYourFace.Characters;
using DG.Tweening;
using MiguelGameDev;
using UnityEngine;
using UnityEngine.UI;

namespace Campero.SkincareInYourFace.UI
{
    public class DialoguePanel : MonoBehaviour
    {
        [SerializeField] private RectTransform _avatarPanel;
        [SerializeField] private RectTransform _parentPanel;
        [SerializeField] private CanvasGroup _dialogueGroup;
        [SerializeField] private Button _hideButton;
        
        [SerializeField] private RectTransform _dialogueContainer;
        [SerializeField] private RectTransform _questionsContainer;
        [SerializeField] private QuestionButton _questionButtonPrefab;
        [SerializeField] private TextPanel _questionPrefab;
        [SerializeField] private TextPanel _answerPrefab;

        private CharacterScreen _screen;
        private Character _character;
        
        private void Awake()
        {
            _hideButton.onClick.AddListener(OnHideButtonClicked);
            _parentPanel.SetAnchoredPositionX(640f);
            _dialogueGroup.alpha = 0;
            _hideButton.gameObject.SetActive(false);
            _avatarPanel.localScale = Vector3.one;
        }

        private void OnHideButtonClicked()
        {
            Hide(
                _screen.BackFromDialoguePanel);
        }

        public void Setup(CharacterScreen screen, Character character)
        {
            _screen = screen;
            _character = character;
            
            _dialogueContainer.DestroyAllChildren();
            _questionsContainer.DestroyAllChildren();
            
            foreach (var talk in _character.Log)
            {
                var question = Instantiate(_questionPrefab, _dialogueContainer);
                question.SetText(talk.Question.Term);
                
                var answer = Instantiate(_answerPrefab, _dialogueContainer);
                answer.SetText(talk.AnswerTerm);
            }

            foreach (var talk in _character.AvailableTalks)
            {
                CreateQuestionButton(talk);
            }

            StartCoroutine(
                WaitAndRebuildQuestions());
            
            StartCoroutine(
                WaitAndRebuildDialogue());
        }
        
        private IEnumerator WaitAndRebuildQuestions()
        {
            yield return new WaitForEndOfFrame();
            LayoutRebuilder.ForceRebuildLayoutImmediate(_questionsContainer);
        }
        
        private IEnumerator WaitAndRebuildDialogue()
        {
            yield return new WaitForEndOfFrame();
            LayoutRebuilder.ForceRebuildLayoutImmediate(_dialogueContainer);
        }

        private void CreateQuestionButton(Talk talk)
        {
            var questionButton = Instantiate(_questionButtonPrefab, _questionsContainer);
            questionButton.Setup(this, talk);
        }
        
        [Sirenix.OdinInspector.Button]
        public void Show()
        {
            _dialogueGroup.alpha = 1f;
            _parentPanel.DOAnchorPosX(0, 0.2f);
            _avatarPanel.DOScale(0.5f, 0.2f).OnComplete(OnComplete);
            
            void OnComplete()
            {
                _hideButton.gameObject.SetActive(true);
            }
        }

        private void Hide(Action callback)
        {
            _hideButton.gameObject.SetActive(false);
            _avatarPanel.DOScale(1f, 0.2f);
            _parentPanel.DOAnchorPosX(640f, 0.2f)
                .OnComplete(OnComplete);

            void OnComplete()
            {
                _dialogueGroup.alpha = 0;
                _avatarPanel.localScale = Vector3.one;
                callback.Invoke();
            }
        }

        public void SelectQuestion(Talk talk)
        {
            var question = Instantiate(_questionPrefab, _dialogueContainer);
            question.SetText(talk.Question.Term);
                
            var answer = Instantiate(_answerPrefab, _dialogueContainer);
            answer.SetText(talk.AnswerTerm);
            
            if (_character.SelectTalkAndTryGetNew(talk, out var newTalk))
            {
                CreateQuestionButton(newTalk);
            }
            
            StartCoroutine(
                WaitAndRebuildQuestions());
            
            StartCoroutine(
                WaitAndRebuildDialogue());
        }
    }
}