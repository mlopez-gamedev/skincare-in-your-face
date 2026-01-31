using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Campero.SkincareInYourFace.Characters
{
    public class Character : MonoBehaviour
    {
        private CharacterModel _model;
        private CharacterDialogue _dialogue;
        
        public CharacterModel Model => _model;
        
        private List<Talk> _reservedTalks = new List<Talk>();
        private List<Talk> _availableTalks = new List<Talk>();
        
        private List<Talk> _log = new List<Talk>();
        
        public List<Talk> AvailableTalks => _availableTalks;
        public List<Talk> Log => _log;
        
        public void Setup(CharacterModel model, CharacterDialogue dialogue)
        {
            _model = model;
            _dialogue = dialogue;
            
            _reservedTalks = new List<Talk>(_dialogue.Interrogatory);
            for (int i = 0; i < 3; ++i)
            {
                TryAddAvailableTalk(out _);
            }
        }
        
        private bool TryAddAvailableTalk(out Talk talk)
        {
            if (_reservedTalks.Count == 0)
            {
                talk = null;
                return false;
            }
            
            talk = _reservedTalks[Random.Range(0, _reservedTalks.Count)];
            _availableTalks.Add(talk);
            _reservedTalks.Remove(talk);
            return true;
        }
        
        public bool SelectTalkAndTryGetNew(Talk talk, out Talk newTalk) 
        {
            Assert.IsTrue(_availableTalks.Contains(talk));
            
            _availableTalks.Remove(talk);
            _log.Add(talk);
            
            return TryAddAvailableTalk(out newTalk);
        }
    }
}