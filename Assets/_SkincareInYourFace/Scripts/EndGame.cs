using Campero.SkincareInYourFace.Audio;
using Campero.SkincareInYourFace.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Campero.SkincareInYourFace
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private GameOverScreen _winScreen;
        [SerializeField] private GameOverScreen _loseScreen;
        
        public void Win()
        {
            AudioPlayer.Instance.StopGameMusic();
            _winScreen.Show();
        }
        
        public void Lose()
        {
            // TODO
            AudioPlayer.Instance.StopGameMusic();
            _loseScreen.Show();
        }
    }
}