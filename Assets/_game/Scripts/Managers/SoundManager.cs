using System;
using System.Collections;
using System.Collections.Generic;
using _game.Enums;
using _game.Signals;
using UnityEngine;

namespace _game.managers
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class SoundManager : MonoBehaviour
    {
        #region SelfVariables

        //serialize
        [SerializeField] private AudioClip[] AudioClips;

        //private 
        private AudioSource _audioSource;

        private Dictionary<SoundState, AudioClip> _sounDictionary = new Dictionary<SoundState, AudioClip>();

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            foreach (SoundState _soundState in (SoundState[])Enum.GetValues(typeof(SoundState)))
            {
                _sounDictionary.Add(_soundState, AudioClips[(int)_soundState]);
            }
        }

        private void Start()
        {
            OnChangeSoundState(SoundState.menu);
        }

        private void OnEnable()
        {
            Subscire();
        }

        private void OnDisable()
        {
            UnSubscire();
        }

        #endregion


        #region MainMethods

        private void OnSoundButton()
        {
            _audioSource.mute = !_audioSource.mute;
        }

        private void OnChangeSoundState(SoundState soundState)
        {
            _audioSource.clip = _sounDictionary[soundState];
            _audioSource.Play();
        }
        private void OnButtonSound(GameObject arg0)
        {
            _audioSource.mute =   !_audioSource.mute;
            arg0.SetActive(!_audioSource.mute);

        }
        #endregion


        #region SubscireMethods

        private void Subscire()
        {
            CoreGameSignals.Instance.onChangeSoundState += OnChangeSoundState;
            CoreGameSignals.Instance.onButtonSound += OnButtonSound;
            CoreGameSignals.Instance.onPlay += () => OnChangeSoundState(SoundState.game);
        }

        private void UnSubscire()
        {
            CoreGameSignals.Instance.onChangeSoundState -= OnChangeSoundState;
            CoreGameSignals.Instance.onButtonSound -= OnButtonSound;
            CoreGameSignals.Instance.onPlay -= () => OnChangeSoundState(SoundState.game);

        }

        #endregion
    }
}