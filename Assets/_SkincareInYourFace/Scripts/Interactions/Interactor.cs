using Campero.SkincareInYourFace.Items;
using UnityEngine;

namespace Campero.SkincareInYourFace.Interactions
{
    public class Interactor : MonoBehaviour
    {
        private IInteractable _interactable;
        
        public CursorModel HighlightCursor => _interactable.Cursor;
        
        public void Setup(IInteractable interactable)
        {
            _interactable  = interactable;
        }

        public void SetHighlight(bool highlight)
        {
            _interactable.SetHighlight(highlight);
        
        }
        public void Interact()
        {
            _interactable.Interact();
        }
    }
}