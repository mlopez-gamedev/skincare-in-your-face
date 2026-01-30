using UnityEngine;

namespace Campero.SkincareInYourFace.Items
{
    public class Item : MonoBehaviour
    {
        private ItemModel _model;
        
        public ItemModel Model => _model;
        
        public void Setup(ItemModel model)
        {
            _model = model;
        }
    }
}