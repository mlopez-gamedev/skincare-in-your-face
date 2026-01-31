using System.Collections.Generic;
using MiguelGameDev;
using UnityEngine;

namespace Campero.SkincareInYourFace.Characters
{
    public class CharacterFactory : SingletonBehaviour<CharacterFactory>
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private CharacterModel[] _models;
        [SerializeField] private CharacterDialogue[] _dialogues;

        private Character[] _characters;
        
        public void GenerateCharacters()
        {
            int characterCount = Mathf.Min(_spawnPoints.Length, _models.Length, _dialogues.Length);

            var availableSpawnPoints = new List<Transform>(_spawnPoints);
            var availableModels = new List<CharacterModel>(_models);
            var availableDialogues = new List<CharacterDialogue>(_dialogues);
            
            _characters = new Character[characterCount];
            for (int i = 0; i < characterCount; i++)
            {
                _characters[i] = GenerateCharacter();
            }
            
            CharacterStates.Instance.SetInfiltrate(_characters[Random.Range(0, characterCount)]);

            Character GenerateCharacter()
            {
                var spawnPoint = availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];
                var model = availableModels[Random.Range(0, availableModels.Count)];
                var dialogue = availableDialogues[Random.Range(0, availableDialogues.Count)];

                var character = Instantiate(model.CharacterPrefab, spawnPoint.position, spawnPoint.rotation);
                character.Setup(model, dialogue);
                
                availableSpawnPoints.Remove(spawnPoint);
                availableModels.Remove(model);
                availableDialogues.Remove(dialogue);
                
                return character;
            }
        }
    }
}