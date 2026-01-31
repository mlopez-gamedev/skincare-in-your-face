using System;
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