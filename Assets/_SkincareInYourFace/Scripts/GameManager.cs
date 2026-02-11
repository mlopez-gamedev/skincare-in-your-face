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
            Debug.Log("Starting Game");
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
        
        public void Win()
        {
            _endGame.Win();
        }
        
        public void Lose()
        {
            _endGame.Lose();
        }
    }
}