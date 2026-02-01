using JetBrains.Annotations;
using MiguelGameDev;
using UnityEngine;

namespace Campero.SkincareInYourFace.Interactions
{
    public class PointerController : SingletonBehaviour<PointerController>
    {
        [SerializeField] private CursorModel _normalCursor;
        [SerializeField] private LayerMask _layerMask;

        [CanBeNull] private Interactor _highlightInteractor;

        private bool _isEnabled;
        
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                if (!_isEnabled)
                {
                    SetCursor(_normalCursor);
                }
            }
        }
        
        private Camera _camera;

        protected override void Awake()
        {
            base.Awake();
            _camera = Camera.main;
            Cursor.SetCursor(
                _normalCursor.Texture,
                _normalCursor.Hotspot,
                CursorMode.Auto);
        }

        private void Update()
        {
            if (!IsEnabled)
            {
                return;
            }
            CheckHover();
            CheckClick();
        }


        private void CheckHover()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _layerMask))
            {
                var interactor = hit.transform.GetComponent<Interactor>();
                if (interactor != null)
                {
                    if (_highlightInteractor == interactor)
                    {
                        return;
                    }

                    if (_highlightInteractor != null)
                    {
                        RemoveHighlight();
                        _highlightInteractor = null;
                    }

                    _highlightInteractor = interactor;
                    AddHighlight();
                }
            }
            else if (_highlightInteractor != null)
            {
                RemoveHighlight();
                _highlightInteractor = null;
            }
        }

        private void AddHighlight()
        {
            _highlightInteractor.SetHighlight(true);
            SetCursor(_highlightInteractor.HighlightCursor);
        }
        
        private void RemoveHighlight()
        {
            _highlightInteractor.SetHighlight(false);
            SetCursor(_normalCursor);
        }

        private void SetCursor(CursorModel cursor)
        {
            Cursor.SetCursor(
                cursor.Texture,
                cursor.Hotspot,
                CursorMode.Auto);
        }

        private void CheckClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _highlightInteractor?.Interact();
            }
        }
    }
}