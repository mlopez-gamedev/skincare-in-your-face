using UnityEngine;
using UnityEngine.Video;

namespace Campero.SkincareInYourFace.UI
{
    public class Intro : MonoBehaviour
    {
        [SerializeField] private VideoPlayer _videoPlayer;
        [SerializeField] private RectTransform _canvas;

        private void Awake()
        {
            _canvas.gameObject.SetActive(true);
        }
        
        public void SkipVideo()
        {
            _videoPlayer.time = _videoPlayer.clip.length;
        }
    }
}