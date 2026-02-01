using System.Collections;
using Campero.SkincareInYourFace.Audio;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Campero.SkincareInYourFace.Items
{
    [RequireComponent(typeof(Graphic))]
    public class ImageDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Graphic _image;
        private ItemSelector _itemSelector;
        
        public void Setup(ItemSelector itemSelector)
        {
            _image = GetComponent<Graphic>();
            _itemSelector = itemSelector;
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            AudioPlayer.Instance.PlayClickUiSound();
            transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.1f).SetEase(Ease.Flash);
            _image.raycastTarget = false;
            _itemSelector.Select();
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            AudioPlayer.Instance.PlayClickUiSound();
            transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.Flash);
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