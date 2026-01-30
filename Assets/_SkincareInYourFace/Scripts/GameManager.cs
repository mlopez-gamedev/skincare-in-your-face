using System;
using Cysharp.Threading.Tasks;
using MiguelGameDev;
using UnityEngine;

namespace Campero.SkincareInYourFace
{
    public class GameManager : SingletonBehaviour<GameManager>
    {
        [SerializeField] private GameLoader _gameLoader;

        private bool _isPlaying;
        public bool IsPlaying => _isPlaying;
        
        public async void StartNewGame()
        {
            try
            {
                await _gameLoader.StartGame();
                _isPlaying = true;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}