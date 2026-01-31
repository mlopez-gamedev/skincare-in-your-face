using UnityEngine;

namespace Campero.SkincareInYourFace.Characters
{
    [System.Serializable]
    public class CharacterDialogue
    {
        [SerializeField] private bool _isInfiltrate;
        [SerializeField] private Talk[] _interrogatory;
        
        public bool IsInfiltrate => _isInfiltrate;
        public Talk[] Interrogatory => _interrogatory;
    }
}