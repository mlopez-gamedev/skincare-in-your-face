using System.Collections.Generic;
using MiguelGameDev;
using UnityEngine;
using UnityEngine.Assertions;

namespace Campero.SkincareInYourFace.Characters
{
    public class CharacterStates : SingletonBehaviour<CharacterStates>
    {
        [SerializeField] private int _maxAccusations = 3;
        
        private GameManager _gameManager;
        
        private Character _infiltrateCharacter;
        private List<Character> _accusedCharacters = new List<Character>();

        private void Start()
        {
            _gameManager = GameManager.Instance;
        }

        public void SetInfiltrate(Character infiltrateCharacter)
        {
            Assert.IsNull(_infiltrateCharacter, "There is more than one infiltrate character.");
            _infiltrateCharacter = infiltrateCharacter;
        }
        
        public void AccuseCharacter(Character character)
        {
            Assert.IsFalse(_accusedCharacters.Contains(character));
            Assert.IsNotNull(_infiltrateCharacter, "There is no infiltrate character.");
            
            if (character == _infiltrateCharacter)
            {
                _gameManager.Win();
                return;
            }
            _accusedCharacters.Add(character);

            if (_accusedCharacters.Count >= _maxAccusations)
            {
                _gameManager.Lose();
            }
        }

        public bool IsInfiltrated(CharacterModel character)
        {
            return _infiltrateCharacter.Model == character;
        }
        
        public bool IsAccused(Character character)
        {
            return _accusedCharacters.Contains(character);
        }
    }
}