using Campero.SkincareInYourFace.Audio;
using UnityEngine;

namespace Campero.SkincareInYourFace.Environment
{
    public class SignAnimationEvents : MonoBehaviour
    {
        private AudioPlayer _audioPlayer;
        private void Start()
        {
            _audioPlayer = AudioPlayer.Instance;
        }
        
        public void PlayLampBlinkRun()
        {
            _audioPlayer.PlayLampBlinkRunSound();
        }
        
        public void PlayLampBlinkShort()
        {
            _audioPlayer.PlayLampBlinkShortSound();
        }
    }
}