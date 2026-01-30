using I2.Loc;
using UnityEngine;

namespace Campero.SkincareInYourFace.Items
{
    [CreateAssetMenu(menuName = "Campero/Item", fileName =  "Item")]
    public class ItemModel : ScriptableObject
    {
        [SerializeField] private GameObject _previewPrefab;
        [SerializeField, TermsPopup("Items/")] private string _nameTerm;
        [SerializeField, TermsPopup("Items/")] private string _descriptionTerm;

        public string Key => name;
        public GameObject PreviewPrefab => _previewPrefab;
        public string NameTerm => _nameTerm;
        public string DescriptionTerm => _descriptionTerm;
    }
}