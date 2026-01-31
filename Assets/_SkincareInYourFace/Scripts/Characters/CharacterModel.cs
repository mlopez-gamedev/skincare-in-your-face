using I2.Loc;
using UnityEngine;

namespace Campero.SkincareInYourFace.Characters
{
    [CreateAssetMenu(menuName = "Campero/Character", fileName =  "Character")]
    public class CharacterModel : ScriptableObject
    {
        [SerializeField, TermsPopup("Characters/")] private string _nameTerm;
        [SerializeField] private Sprite _characterAvatar;
        [SerializeField] private Character _characterPrefab;
        
        public string Key => name;
        public string NameTerm => _nameTerm;
        public Sprite CharacterAvatar => _characterAvatar;
        public Character CharacterPrefab => _characterPrefab;
    }
}