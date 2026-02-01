using FMOD.Studio;
using MiguelGameDev;
using UnityEngine;
using FMODUnity;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace Campero.SkincareInYourFace.Audio
{
    public class AudioPlayer : SingletonBehaviour<AudioPlayer>
    {
        [SerializeField] private EventReference _menuMusicEvent;
        [SerializeField] private EventReference _gameMusicEvent;
        
        [SerializeField] private EventReference _clickUiEvent;
        
        [SerializeField] private EventReference _openUiEvent;
        [SerializeField] private EventReference _closeUiEvent;

        private EventInstance _menuMusicEventInstance;
        private EventInstance _gameMusicEventInstance;
        private EventInstance _clickUiEventInstance;
        private EventInstance _openUiEventInstance;
        private EventInstance _closeUiEventInstance;
        
        protected override void Awake()
        {
            base.Awake();
            _menuMusicEventInstance = RuntimeManager.CreateInstance(_menuMusicEvent);
            _gameMusicEventInstance = RuntimeManager.CreateInstance(_gameMusicEvent);
            _clickUiEventInstance = RuntimeManager.CreateInstance(_clickUiEvent);
            _openUiEventInstance = RuntimeManager.CreateInstance(_openUiEvent);
            _closeUiEventInstance = RuntimeManager.CreateInstance(_closeUiEvent);
        }
        
        public void PlayMenuMusic()
        {
            _menuMusicEventInstance.start();
        }
        
        public void StopMenuMusic()
        {
            _menuMusicEventInstance.stop(STOP_MODE.ALLOWFADEOUT);
        }
        
        public void PlayGameMusic()
        {
            _gameMusicEventInstance.start();
        }
        
        public void StopGameMusic()
        {
            _gameMusicEventInstance.stop(STOP_MODE.ALLOWFADEOUT);
        }
                
        public void PlayClickUiSound()
        {
            _clickUiEventInstance.start();
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