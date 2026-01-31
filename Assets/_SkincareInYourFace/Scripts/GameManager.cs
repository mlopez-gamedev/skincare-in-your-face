using System;
using Campero.SkincareInYourFace.Audio;
using MiguelGameDev;
using UnityEngine;

namespace Campero.SkincareInYourFace
{
    public class GameManager : SingletonBehaviour<GameManager>
    {
        [SerializeField] private GameLoader _gameLoader;

        private void Start()
        {
            AudioPlayer.Instance.PlayMenuMusic();
        }
        
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

        public void ActivateUI()
        {
            
        }
        
        public void Win()
        {
            // TODO: WIN
            Debug.Log($"You win");   
        }
        
        public void Lose()
        {
            // TODO: LOSE
            Debug.Log($"You lose");   
        }
    }
}