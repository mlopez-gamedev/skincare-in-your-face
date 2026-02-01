using MiguelGameDev;
using UnityEngine;

namespace Campero.SkincareInYourFace.Items
{
    public class ItemPreviewCamera : MonoBehaviour
    {
        [SerializeField] private Transform _itemContainer;
        [SerializeField] private Camera _camera;
        
        public bool IsEmpty => !gameObject.activeSelf; 
        
        public void Init(ItemModel item)
        {
            var itemPreview = Instantiate(item.PreviewPrefab, _itemContainer);
            itemPreview.layer = LayerMask.NameToLayer("UiPreview");
            gameObject.SetActive(true);
        }
        
        public RenderTexture GetTexture()
        {
            return _camera.targetTexture;
        }

        public void Clear()
        {
            _itemContainer.DestroyAllChildren();
            gameObject.SetActive(false);
        }
    }
}