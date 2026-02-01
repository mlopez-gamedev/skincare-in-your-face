using Campero.SkincareInYourFace.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Campero.SkincareInYourFace.Items
{
    public class ImageDrop : MonoBehaviour, IDropHandler
    {
        private AccusationPanel _accusationPanel;
        private RectTransform _rectTransform;
        
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            _accusationPanel.Accuse();
        }

        public void Setup(AccusationPanel accusationPanel)
        {
            _accusationPanel  = accusationPanel;
        }
    }
}