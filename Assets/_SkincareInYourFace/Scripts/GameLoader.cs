using Campero.SkincareInYourFace.Audio;
using Campero.SkincareInYourFace.Characters;
using Campero.SkincareInYourFace.Environment;
using Campero.SkincareInYourFace.Interactions;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Campero.SkincareInYourFace
{
    public class GameLoader : MonoBehaviour
    {
        [SerializeField] private VideoPlayer _videoPlayer;
        [SerializeField] private CanvasGroup _videoImage;
        
        public async UniTask StartGame()
        {
            AudioPlayer.Instance.StopMenuMusic();

            _videoImage.gameObject.SetActive(true);
            _videoImage.DOFade(1f, 0.2f);
            //await PlayIntro();
            await _videoImage.DOFade(0, 0.5f).AsyncWaitForCompletion();
            _videoImage.gameObject.SetActive(false);
            
            CharacterFactory.Instance.GenerateCharacters();
            CameraMovement.Instance.CanMove = true;
            PointerController.Instance.IsEnabled = true;
            AudioPlayer.Instance.PlayGameMusic();
        }

        private UniTask PlayIntro()
        {
            var introTaskCompletionSource = new UniTaskCompletionSource();
            
            _videoPlayer.seekCompleted += OnSeekCompleted;
            _videoPlayer.Play();

            return introTaskCompletionSource.Task;

            void OnSeekCompleted(VideoPlayer _)
            {
                introTaskCompletionSource.TrySetResult();
            }
        }
    }
}
