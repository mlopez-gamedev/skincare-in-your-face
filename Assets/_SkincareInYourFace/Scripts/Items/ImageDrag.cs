using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Campero.SkincareInYourFace.Items
{
    [RequireComponent(typeof(RawImage))]
    public class ImageDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RawImage _image;
        private ItemSelector _itemSelector;
        
        public void Setup(ItemSelector itemSelector)
        {
            _image = GetComponent<RawImage>();
            _itemSelector = itemSelector;
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            _image.raycastTarget = false;
            _itemSelector.Select();
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.DOLocalMove(Vector3.zero, 0.1f).SetEase(Ease.Flash)
                .OnComplete(OnComplete);

            void OnComplete()
            {
                _itemSelector.Deselect();
                _image.raycastTarget = true;
            }
        }
    }
}