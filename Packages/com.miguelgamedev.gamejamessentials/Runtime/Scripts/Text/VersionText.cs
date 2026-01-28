using TMPro;
using UnityEngine;

namespace MiguelGameDev
{
    public class VersionText : MonoBehaviour
    {
        [SerializeField] TMP_Text _text;
        [SerializeField] string _textFormat = "v{0}";

        private void Awake()
        {
            _text.text = string.Format(_textFormat, Application.version);
        }
    }
}
