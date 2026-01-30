using System;
using Campero.SkincareInYourFace.Environment;
using Campero.SkincareInYourFace.Items;
using DG.Tweening;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

namespace Campero.SkincareInYourFace.UI
{
    public class ItemScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _panel;
        [SerializeField] private Button _hideButton;
        [SerializeField] private Localize _nameText;
        [SerializeField] private Localize _descriptionText;
        [SerializeField] private Transform _itemPreview;
        [SerializeField] private Transform _itemPreviewParent;

        private int _previewLayer;
        private GameObject _item;

        private void Awake()
        {
            _previewLayer = LayerMask.NameToLayer("UiPreview");
            
            _panel.alpha = 0;
            _panel.gameObject.SetActive(false);
            _itemPreview.gameObject.SetActive(false);
            
            _hideButton.onClick.AddListener(Hide);
        }

        [Sirenix.OdinInspector.Button]
        public void Show(ItemModel item) 
        {
            CameraMovement.Instance.CanMove = false;
            _nameText.SetTerm(item.ItemNameTerm);
            _descriptionText.SetTerm(item.ItemDescriptionTerm);
            _item = Instantiate(item.ItemPrefab, _itemPreviewParent);
            _item.layer = _previewLayer;
			_itemPreview.gameObject.SetActive(true);
            _panel.gameObject.SetActive(true);
            _panel.DOFade(1f, 0.2f);
        }
        
        private void Hide() 
        {
            _panel.DOFade(0f, 0.2f)
                .OnComplete(OnComplete);
            
            void OnComplete()
            {
                _panel.gameObject.SetActive(false);
				_itemPreview.gameObject.SetActive(false);
                Destroy(_item);
                CameraMovement.Instance.CanMove = true;
            } 
                
        }
    }
}