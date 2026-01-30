using System;
using Campero.SkincareInYourFace.Environment;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Campero.SkincareInYourFace
{
    public class GameLoader : MonoBehaviour
    {
        public async UniTask StartGame()
        {
            // TODO: Play intro
            Debug.Log("Play intro");
            await UniTask.Delay(200);
            // TODO: init game state
            CameraMovement.Instance.CanMove = true;
            Debug.Log("Game Started");
        }
    }
}
