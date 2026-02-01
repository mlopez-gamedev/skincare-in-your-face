using Campero.SkincareInYourFace.Audio;
using Campero.SkincareInYourFace.Characters;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

namespace Campero.SkincareInYourFace.UI
{
    public class QuestionButton : MonoBehaviour
    {
        [SerializeField] private Localize _questionText;
        [SerializeField] private Button _button;

        private DialoguePanel _dialoguePanel;
        private Talk _talk;
        
        public void Setup(DialoguePanel dialoguePanel, Talk talk)
        {
            _dialoguePanel = dialoguePanel;
            _talk = talk;
            
            _questionText.SetTerm(talk.Question.Term);
            _button.onClick.AddListener(OnQuestionClicked);
        }
        
        private void OnQuestionClicked()
        {
            AudioPlayer.Instance.PlayClickUiSound();
            _dialoguePanel.SelectQuestion(_talk);
            Destroy(gameObject);
        }
    }
}