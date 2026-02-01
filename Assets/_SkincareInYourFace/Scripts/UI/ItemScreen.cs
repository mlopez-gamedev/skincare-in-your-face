using System;
using Campero.SkincareInYourFace.Audio;
using Campero.SkincareInYourFace.Characters;
using Campero.SkincareInYourFace.Environment;
using Campero.SkincareInYourFace.Interactions;
using Campero.SkincareInYourFace.Items;
using DG.Tweening;
using I2.Loc;
using MiguelGameDev;
using UnityEngine;
using UnityEngine.UI;

namespace Campero.SkincareInYourFace.UI
{
    public class ItemScreen : SingletonBehaviour<ItemScreen>
    {
        [SerializeField] private CanvasGroup _panel;
        [SerializeField] private Button _hideButton;
        [SerializeField] private Localize _nameText;
        [SerializeField] private Localize _descriptionText;
        [SerializeField] private Transform _itemPreview;
        [SerializeField] private Transform _itemPreviewParent;
        
        private int _previewLayer;
        private GameObject _preview;
        private AudioPlayer _audioPlayer;

        protected override void Awake()
        {
            base.Awake();
            
            _audioPlayer = AudioPlayer.Instance;
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
            PointerController.Instance.IsEnabled = false;
            
            _nameText.SetTerm(item.NameTerm);

            if (CharacterStates.Instance.IsInfiltrated(item.ItemOwner))
            {
                _descriptionText.SetTerm(item.InfiltratedDescriptionTerm);    
            }
            else
            {
                _descriptionText.SetTerm(item.NormalDescriptionTerm);
            }
            
            _preview = Instantiate(item.PreviewPrefab, _itemPreviewParent);
            _preview.layer = _previewLayer;
			_itemPreview.gameObject.SetActive(true);
            _panel.gameObject.SetActive(true);
            
            _panel.DOFade(1f, 0.2f);
            _audioPlayer.PlayOpenUiSound();
            
            ItemStates.Instance.ViewItem(item);
        }
        
        private void Hide() 
        {
            _audioPlayer.PlayCloseUiSound();
            _panel.DOFade(0f, 0.2f)
                .OnComplete(OnComplete);
            
            void OnComplete()
            {
                _panel.gameObject.SetActive(false);
				_itemPreview.gameObject.SetActive(false);
                Destroy(_preview);
                CameraMovement.Instance.CanMove = true;
                PointerController.Instance.IsEnabled = true;
            } 
        }
    }
}