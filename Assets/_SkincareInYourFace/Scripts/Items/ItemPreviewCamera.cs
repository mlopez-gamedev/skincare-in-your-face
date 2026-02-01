using MiguelGameDev;
using UnityEngine;

namespace Campero.SkincareInYourFace.Items
{
    public class ItemPreviewCamera : MonoBehaviour
    {
        [SerializeField] private Transform _itemContainer;
        [SerializeField] private Camera _camera;

        public bool IsEmpty => gameObject.activeSelf; 
        
        public void Init(ItemModel item)
        {
            Instantiate(item.PreviewPrefab, _itemContainer);
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