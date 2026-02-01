using UnityEngine;
using UnityEngine.Video;

namespace Campero.SkincareInYourFace.UI
{
    public class Intro : MonoBehaviour
    {
        [SerializeField] private VideoPlayer _videoPlayer;
        
        public void SkipVideo()
        {
            _videoPlayer.time = _videoPlayer.clip.length;
        }
    }
}