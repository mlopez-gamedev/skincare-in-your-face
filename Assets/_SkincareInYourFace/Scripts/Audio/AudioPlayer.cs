using FMOD.Studio;
using MiguelGameDev;
using UnityEngine;
using FMODUnity;

namespace Campero.SkincareInYourFace.Audio
{
    public class AudioPlayer : SingletonBehaviour<AudioPlayer>
    {
        [SerializeField] private EventReference _openUiEvent;
        [SerializeField] private EventReference _closeUiEvent;

        private EventInstance _openUiEventInstance;
        private EventInstance _closeUiEventInstance;
        
        protected override void Awake()
        {
            base.Awake();
            _openUiEventInstance = RuntimeManager.CreateInstance(_openUiEvent);
            _closeUiEventInstance = RuntimeManager.CreateInstance(_closeUiEvent);
        }
        
        public void PlayOpenUiSound()
        {
            _openUiEventInstance.start();
        }
        
        public void PlayCloseUiSound()
        {
            _closeUiEventInstance.start();
        }
    }
}