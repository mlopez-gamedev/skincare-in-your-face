using System.Collections;
using TMPro;
using UnityEngine;

namespace MiguelGameDev
{
    public class TextCycledVisibility : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private int _index = -3;
        [SerializeField] private int _count = 3;
        [SerializeField] private float _delay = 0.5f;
        [SerializeField] private bool _autoplay = true;

        private Cycle _cycle;

        private void OnEnable()
        {
            if (!_autoplay)
            {
                return;
            }

            StartCoroutine(
                WaitOneFrameAndPlay());
        }

        private IEnumerator WaitOneFrameAndPlay()
        {
            yield return new WaitForEndOfFrame();
            yield return Play();
        }

        public IEnumerator Play()
        {
            SetCycle();
            _text.maxVisibleCharacters = _cycle.Value;

            while (gameObject.activeInHierarchy)
            {
                yield return new WaitForSeconds(_delay);
                _text.maxVisibleCharacters = _cycle.Next();
            }
        }

        private void SetCycle()
        {
            int origin = _index < 0 ?
                Mathf.Max(0, _text.textInfo.characterCount + _index) :
                _index;

            int final = Mathf.Min(_text.textInfo.characterCount, origin + _count);

            _cycle = new Cycle(origin, final, origin);
        }
    }
}
