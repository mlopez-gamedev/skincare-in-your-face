using System.Collections;
using I2.Loc;
using UnityEngine;

namespace Campero.SkincareInYourFace.UI
{
    public class TextPanel : MonoBehaviour
    {
        [SerializeField] private Localize _messageText;
        [SerializeField] private RectTransform _messagePanel;

        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
        
        [Sirenix.OdinInspector.Button]
        public void SetText(string messageTerm)
        {
            _messageText.SetTerm(messageTerm);
            StartCoroutine(
                WaitAndResize());
        }

        private IEnumerator WaitAndResize()
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            _rectTransform.SetSizeDeltaY(_messagePanel.sizeDelta.y);
        }
    }
}