using I2.Loc;
using UnityEngine;
using UnityEngine.Serialization;

namespace Campero.SkincareInYourFace.Characters
{
    [CreateAssetMenu(fileName = "Question", menuName = "Campero/Question")]
    public class Question : ScriptableObject
    {
        [SerializeField, TermsPopup("Questions/")] private string _term;
        
        public string Term => _term;
    }
}