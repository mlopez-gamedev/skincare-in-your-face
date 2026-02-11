using Campero.SkincareInYourFace.Audio;
using Campero.SkincareInYourFace.Characters;
using Campero.SkincareInYourFace.Environment;
using Campero.SkincareInYourFace.Interactions;
using Campero.SkincareInYourFace.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Campero.SkincareInYourFace
{
    public class GameLoader : MonoBehaviour
    {
        [SerializeField] private Intro _intro;
        [SerializeField] private Animator _signAnimator;

        private void Awake()
        {
            _signAnimator.enabled = false;
        }
        
        public async UniTask StartGame()
        {
            AudioPlayer.Instance.StopMenuMusic();
            await _intro.Play();
            CharacterFactory.Instance.GenerateCharacters();
            CameraMovement.Instance.CanMove = true;
            PointerController.Instance.IsEnabled = true;
            _signAnimator.enabled = true;
            AudioPlayer.Instance.PlayGameMusic();
        }
        
    }
}
