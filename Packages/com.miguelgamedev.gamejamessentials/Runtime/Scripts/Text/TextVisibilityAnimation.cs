using TMPro;
using UnityEngine;
using System.Collections;

namespace MiguelGameDev
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextVisibilityAnimation : MonoBehaviour
    {
        private TMP_Text _text;

        [SerializeField]
        private bool _playOnStart = true;

        [SerializeField]
        private float _delayScale = 1f;

        [SerializeField]
        private float _breakDelayScale = 1f;

        [SerializeField]
        private float _firstDelay = 0.1f;

        private Coroutine _showCoroutine;

        private bool _isAnimating;
        private int _suspendedPoints;

        public event System.Action OnWriteChar;
        public event System.Action OnComplete;

        public bool IsComplete => _text != null && _text.maxVisibleCharacters == _text.textInfo.characterCount;

        public TMP_Text Text {
            get {
                if (_text == null)
                {
                    _text = GetComponent<TMP_Text>();
                }
                return _text;
            }
        }

        private void Start()
        {
            if (_playOnStart)
            {
                Play();
                return;
            }

            Text.maxVisibleCharacters = 0;
        }

        public void Play()
        {
            Text.maxVisibleCharacters = 0;
            _isAnimating = true;
            _showCoroutine = StartCoroutine(
                ShowNextDelayed(_firstDelay));
        }

        public void Play(string text)
        {
            Text.text = text;
            Play();
        }

        private IEnumerator ShowNextDelayed(float delay)
        {
            yield return new WaitForSeconds(delay);
            ShowNext();
        }

        public void Continue()
        {
            if (_isAnimating)
            {
                return;
            }
            
            _showCoroutine = StartCoroutine(
                ShowNextDelayed(_firstDelay));
            _isAnimating = true;
        }

        public void AppendText(string text)
        {
            Text.text += text;
            if (_isAnimating)
            {
                return;
            }
            
            _showCoroutine = StartCoroutine(
                ShowNextDelayed(_firstDelay));
            _isAnimating = true;
        }

        public void AppendLine()
        {
            Text.text += "\n";
        }

        public void AppendLine(string text)
        {
            Text.text += "\n" + text;
            if (_isAnimating)
            {
                return;
            }
            
            _showCoroutine = StartCoroutine(
                ShowNextDelayed(_firstDelay));
            _isAnimating = true;
        }

        public void Complete()
        {
            StopCoroutine(_showCoroutine);
            Text.maxVisibleCharacters = Text.textInfo.characterCount;
            _isAnimating = false;

            OnComplete?.Invoke();
        }

        private void ShowNext()
        {
            if (Text.maxVisibleCharacters >= Text.textInfo.characterCount)
            {
                Complete();
                return;
            }

            switch (Text.textInfo.characterInfo[Text.maxVisibleCharacters].character)
            {
                case ',':
                    if (_delayScale == 0)
                    {
                        ++Text.maxVisibleCharacters;
                        ShowNext();
                        return;
                    }
                    else
                    {
                        if (IsANumberSymbol())
                        {
                            _showCoroutine = StartCoroutine(
                                ShowNextDelayed(Random.Range(0.05f, 0.01f) * _delayScale));
                            break;
                        }
                        _showCoroutine = StartCoroutine(
                            ShowNextDelayed(0.15f * _delayScale));
                    }
                    break;

                case ';':
                    if (_delayScale == 0)
                    {
                        ++Text.maxVisibleCharacters;
                        ShowNext();
                        return;
                    }
                    else
                    {
                        _showCoroutine = StartCoroutine(
                            ShowNextDelayed(0.15f * _delayScale));
                    }
                    break;

                case '.':
                    if (_delayScale == 0)
                    {
                        ++Text.maxVisibleCharacters;
                        ShowNext();
                        return;
                    }
                    else
                    {
                        if (_suspendedPoints > 0)
                        {
                            if (_suspendedPoints == 1)
                            {
                                _showCoroutine = StartCoroutine(
                                    ShowNextDelayed(0.2f * _delayScale));
                            }
                            else
                            {
                                _showCoroutine = StartCoroutine(
                                    ShowNextDelayed(0.1f * _delayScale));
                            }
                            --_suspendedPoints;
                        }
                        else
                        {
                            if (IsANumberSymbol())
                            {
                                _showCoroutine = StartCoroutine(
                                    ShowNextDelayed(Random.Range(0.05f, 0.01f) * _delayScale));
                                break;
                            }

                            int i = Text.maxVisibleCharacters + 1;
                            for (; i < Text.textInfo.characterCount; ++i)
                            {
                                if (Text.textInfo.characterInfo[i].character != '.')
                                {
                                    break;
                                }
                                ++_suspendedPoints;
                            }
                            if (_suspendedPoints >= 1)
                            {
                                _showCoroutine = StartCoroutine(
                                    ShowNextDelayed(0.1f * _delayScale));
                            }
                            else
                            {
                                _suspendedPoints = 0;
                                _showCoroutine = StartCoroutine(
                                    ShowNextDelayed(0.1f * _delayScale));
                            }
                        }
                    }
                    break;

                    case '\n':
                        if (_breakDelayScale == 0)
                        {
                            ++Text.maxVisibleCharacters;
                            ShowNext();
                            return;
                        }
                        else
                        {
                            _showCoroutine = StartCoroutine(
                                ShowNextDelayed(0.25f * _delayScale));
                        }
                    break;

                default:
                    if (_delayScale == 0)
                    {
                        ++Text.maxVisibleCharacters;
                        ShowNext();
                        return;
                    }
                    else
                    {
                        _showCoroutine = StartCoroutine(
                            ShowNextDelayed(Random.Range(0.05f, 0.01f) * _delayScale));
                    }
                    break;
            }
            OnWriteChar?.Invoke();
            ++Text.maxVisibleCharacters;
        }

        private bool IsANumberSymbol()
        {
            int nextCharacterIndex = Text.maxVisibleCharacters + 1;
            if (Text.textInfo.characterCount <= nextCharacterIndex)
            {
                return false;
            }

            return int.TryParse(Text.textInfo.characterInfo[nextCharacterIndex].character.ToString(), out int number);
        }

        public void Clear()
        {
            if (_isAnimating)
            {
                StopCoroutine(_showCoroutine);
                _isAnimating = false;
            }
            Text.text = string.Empty;
        }
    }
}