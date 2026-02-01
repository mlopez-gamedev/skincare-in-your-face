using Campero.SkincareInYourFace.Audio;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Campero.SkincareInYourFace
{
    public class EndGame : MonoBehaviour
    {
        public async UniTask Win()
        {
            // TODO
            AudioPlayer.Instance.StopGameMusic();
            await UniTask.Delay(500);
            SceneManager.LoadScene(0);
        }
        
        public async UniTask Lose()
        {
            // TODO
            AudioPlayer.Instance.StopGameMusic();
            await UniTask.Delay(500);
            SceneManager.LoadScene(0);
        }
    }
}