using I2.Loc;
using UnityEngine;

namespace Campero.SkincareInYourFace.Characters
{
    [System.Serializable]
    public class Talk
    {
        [SerializeField] private Question _question;
        [SerializeField, TermsPopup] private string _answerTerm;
        
        public Question Question => _question;
        public string AnswerTerm => _answerTerm;
    }
}