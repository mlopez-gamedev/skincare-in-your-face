using Campero.SkincareInYourFace.Characters;
using I2.Loc;
using UnityEngine;

namespace Campero.SkincareInYourFace.Items
{
    [CreateAssetMenu(menuName = "Campero/Item", fileName =  "Item")]
    public class ItemModel : ScriptableObject
    {
        [SerializeField] private GameObject _previewPrefab;
        [SerializeField] private Sprite _previewSprite;
        [SerializeField, TermsPopup("Items/")] private string _nameTerm;
        [SerializeField, TermsPopup("Items/")] private string _normalDescriptionTerm;
        [SerializeField, TermsPopup("Items/")] private string _infiltratedDescriptionTerm;
        [SerializeField] private CharacterModel _itemOwner;

        public string Key => name;
        public GameObject PreviewPrefab => _previewPrefab;
        public Sprite PreviewSprite => _previewSprite;
        public string NameTerm => _nameTerm;
        public string NormalDescriptionTerm => _normalDescriptionTerm;
        public string InfiltratedDescriptionTerm => _infiltratedDescriptionTerm;
        public CharacterModel ItemOwner => _itemOwner;
    }
}