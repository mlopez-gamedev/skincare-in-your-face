using Sirenix.OdinInspector;
using UnityEngine;

namespace Campero.SkincareInYourFace.Characters
{
    [CreateAssetMenu(menuName = "Campero/Dialogue", fileName =  "Dialogue")]
    public class CharacterDialogue : ScriptableObject
    {
        [SerializeField] private Talk[] _interrogatory;
        
        public Talk[] Interrogatory => _interrogatory;

        [Button]
        private void Fill(int id)
        {
            for (int i = 0; i < _interrogatory.Length; i++)
            {
                _interrogatory[i].SetAnswer($"Answers/Q{i}_Answer_{id}");
            }   
        }
    }
}