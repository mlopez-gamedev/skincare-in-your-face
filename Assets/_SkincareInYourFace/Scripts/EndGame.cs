using System;
using Campero.SkincareInYourFace.Audio;
using Campero.SkincareInYourFace.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Campero.SkincareInYourFace
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private Animator _signAnimator;
        [SerializeField] private GameOverScreen _winScreen;
        [SerializeField] private GameOverScreen _loseScreen;
        
        private AudioPlayer _audioPlayer;

        private void Awake()
        {
            _audioPlayer = AudioPlayer.Instance;
        }

        public void Win()
        {
            _signAnimator.enabled = false;
            _audioPlayer.StopGameMusic();
            _audioPlayer.PlayWinSound();
            _winScreen.Show();
        }
        
        public void Lose()
        {
            _signAnimator.enabled = false;
            _audioPlayer.StopGameMusic();
            _audioPlayer.PlayLoseSound();
            _loseScreen.Show();
        }
    }
}