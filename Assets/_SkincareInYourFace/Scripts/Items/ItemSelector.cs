using System;
using Campero.SkincareInYourFace.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Campero.SkincareInYourFace.Items
{
    public class ItemSelector : MonoBehaviour
    {
        [SerializeField] private RectTransform _previewPanel;
        [SerializeField] private RawImage _previewImage;
        [SerializeField] private ImageDrag _imageDrag;

        private AccusationPanel _accusationPanel;
        private ItemPreviewCamera _itemPreviewCamera;
        private ItemModel _item;
        
        public void Init(AccusationPanel accusationPanel, ItemModel item)
        {
            _accusationPanel = accusationPanel;
            _item = item;
            _itemPreviewCamera = ItemPreviews.Instance.GetPreviewCamera(item);
            _previewImage.texture = _itemPreviewCamera.GetTexture();
            _imageDrag.Setup(this);
        }
        
        private void LateUpdate()
        {
            _previewPanel.rotation = Quaternion.identity;
        }

        private void OnDestroy()
        {
            _itemPreviewCamera.Clear();
        }

        public void Select()
        {
            Debug.Log("Select " + _item.Key);
            _accusationPanel.SelectItem(_item);
        }

        public void Deselect()
        {
            Debug.Log("Deselect " + _item.Key);
            _accusationPanel.DeselectItem();
        }
    }
}