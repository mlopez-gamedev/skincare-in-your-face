using System;
using Campero.SkincareInYourFace.Audio;
using Campero.SkincareInYourFace.Characters;
using Campero.SkincareInYourFace.Environment;
using Campero.SkincareInYourFace.Interactions;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Campero.SkincareInYourFace
{
    public class GameLoader : MonoBehaviour
    {
        public async UniTask StartGame()
        {
            AudioPlayer.Instance.StopMenuMusic();
            // TODO: Play intro
            Debug.Log("Play intro");
            CharacterFactory.Instance.GenerateCharacters();
            await UniTask.Delay(200);
            // TODO: init game state
            CameraMovement.Instance.CanMove = true;
            PointerController.Instance.IsEnabled = true;
            AudioPlayer.Instance.PlayGameMusic();
            Debug.Log("Game Started");
        }
    }
}
