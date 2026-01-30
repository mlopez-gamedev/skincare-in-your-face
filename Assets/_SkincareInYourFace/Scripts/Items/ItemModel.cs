using I2.Loc;
using UnityEngine;

namespace Campero.SkincareInYourFace.Items
{
    [CreateAssetMenu(menuName = "Campero/Item", fileName =  "Item")]
    public class ItemModel : ScriptableObject
    {
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField, TermsPopup("Items/")] private string _itemNameTerm;
        [SerializeField, TermsPopup("Items/")] private string _itemDescriptionTerm;

        public string Key => name;
        public GameObject ItemPrefab => _itemPrefab;
        public string ItemNameTerm => _itemNameTerm;
        public string ItemDescriptionTerm => _itemDescriptionTerm;
    }
}