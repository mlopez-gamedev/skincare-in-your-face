using Campero.SkincareInYourFace.Interactions;
using Campero.SkincareInYourFace.UI;
using UnityEngine;

namespace Campero.SkincareInYourFace.Items
{
    public class Item : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemModel _model;
        [SerializeField] private CursorModel _cursor;
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private Material _highlightMaterial;
        private Interactor _interactor;
        
        public ItemModel Model => _model;
        public CursorModel Cursor => _cursor;
        
        private void Start()
        {
            _interactor = GetComponentInChildren<Interactor>();
            _interactor.Setup(this);
        }

        public void Interact()
        {
            ItemScreen.Instance.Show(_model);
        }

        public void SetHighlight(bool highlight)
        {
            //Debug.Log($"{name} highlight: {highlight}");
            // if (highlight)
            // {
            //     _renderer.materials = new[]
            //     {
            //         _renderer.materials[0],
            //         new Material(_highlightMaterial)
            //     };
            // }
            // else 
            // {
            //     _renderer.materials = new[]
            //     {
            //         _renderer.materials[0]
            //     };
            // }
        }
    }
}