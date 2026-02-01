using System;
using Campero.SkincareInYourFace.Audio;
using MiguelGameDev;
using UnityEngine;

namespace Campero.SkincareInYourFace
{
    public class GameManager : SingletonBehaviour<GameManager>
    {
        [SerializeField] private GameLoader _gameLoader;
        [SerializeField] private EndGame _endGame;

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
        
        public async void Win()
        {
            Debug.Log($"You win");
            try
            {
                await _endGame.Win();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        
        public async void Lose()
        {
            Debug.Log($"You lose");   
            try
            {
                await _endGame.Lose();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}