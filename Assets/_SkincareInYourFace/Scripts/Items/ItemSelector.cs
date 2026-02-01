using UnityEngine;
using UnityEngine.UI;

namespace Campero.SkincareInYourFace.Items
{
    public class ItemSelector : MonoBehaviour
    {
        [SerializeField] private RawImage _previewImage;
        
        private ItemPreviewCamera _itemPreviewCamera;
        
        public void Init(ItemModel item)
        {
            _itemPreviewCamera = ItemPreviews.Instance.GetPreviewCamera(item);
            _previewImage.texture = _itemPreviewCamera.GetTexture();
        }

        private void OnDestroy()
        {
            _itemPreviewCamera.Clear();
        }
    }
}