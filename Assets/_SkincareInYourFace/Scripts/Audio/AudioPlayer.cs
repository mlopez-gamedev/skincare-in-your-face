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
        
        [SerializeField] private EventReference _talkEvent;
        [SerializeField] private EventReference _accuseEvent;

        [SerializeField] private EventReference _lampBlinkRunEvent;
        [SerializeField] private EventReference _lampBlinkShortEvent;
        
        private EventInstance _menuMusicEventInstance;
        private EventInstance _gameMusicEventInstance;
        private EventInstance _clickUiEventInstance;
        private EventInstance _openUiEventInstance;
        private EventInstance _closeUiEventInstance;
        private EventInstance _talkEventInstance;
        private EventInstance _accuseEventInstance;
        private EventInstance _lampBlinkRunEventInstance;
        private EventInstance _lampBlinkShortEventInstance;
        
        protected override void Awake()
        {
            base.Awake();
            _menuMusicEventInstance = RuntimeManager.CreateInstance(_menuMusicEvent);
            _gameMusicEventInstance = RuntimeManager.CreateInstance(_gameMusicEvent);
            _clickUiEventInstance = RuntimeManager.CreateInstance(_clickUiEvent);
            _openUiEventInstance = RuntimeManager.CreateInstance(_openUiEvent);
            _closeUiEventInstance = RuntimeManager.CreateInstance(_closeUiEvent);
            _talkEventInstance = RuntimeManager.CreateInstance(_talkEvent);
            _accuseEventInstance = RuntimeManager.CreateInstance(_accuseEvent);
            _lampBlinkRunEventInstance = RuntimeManager.CreateInstance(_lampBlinkRunEvent);
            _lampBlinkShortEventInstance = RuntimeManager.CreateInstance(_lampBlinkShortEvent);
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
        
        public void PlayTalkSound()
        {
            _talkEventInstance.start();
        }
        
        public void PlayAccuseSound()
        {
            _accuseEventInstance.start();
        }

        public void PlayLampBlinkRunSound()
        {
            _lampBlinkRunEventInstance.start();
        }

        public void PlayLampBlinkShortSound()
        {
            _lampBlinkShortEventInstance.start();
        }
    }
}