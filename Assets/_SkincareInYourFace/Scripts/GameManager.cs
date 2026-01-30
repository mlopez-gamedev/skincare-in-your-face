using System;
using Cysharp.Threading.Tasks;
using MiguelGameDev;
using UnityEngine;

namespace Campero.SkincareInYourFace
{
    public class GameManager : SingletonBehaviour<GameManager>
    {
        [SerializeField] private GameLoader _gameLoader;
        
        public async void StartNewGame()
        {
            try
            {
                await _gameLoader.StartGame();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}