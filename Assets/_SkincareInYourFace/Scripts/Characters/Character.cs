using System.Collections.Generic;
using Campero.SkincareInYourFace.Interactions;
using Campero.SkincareInYourFace.UI;
using UnityEngine;
using UnityEngine.Assertions;

namespace Campero.SkincareInYourFace.Characters
{
    public class Character : MonoBehaviour, IInteractable
    {
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private Material _highlightMaterial;
        [SerializeField] private CursorModel _cursor;
        private Interactor _interactor;
        
        private CharacterModel _model;
        private CharacterDialogue _dialogue;
        
        public CharacterModel Model => _model;
        public CursorModel Cursor => _cursor;
        
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
            
            _interactor = GetComponentInChildren<Interactor>();
            _interactor.Setup(this);
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

        public void Interact()
        {
            CharacterScreen.Instance.Show(this);
        }

        public void SetHighlight(bool highlight)
        {
            Debug.Log($"{name} highlight: {highlight}");
            if (highlight)
            {
                _renderer.materials = new[]
                {
                    _renderer.materials[0],
                    new Material(_highlightMaterial)
                };
            }
            else 
            {
                _renderer.materials = new[]
                {
                    _renderer.materials[0]
                };
            }
        }
    }
}