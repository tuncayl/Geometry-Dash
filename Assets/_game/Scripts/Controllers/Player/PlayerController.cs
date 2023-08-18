using System;
using System.Collections;
using System.Collections.Generic;
using _game.Data;
using _game.Enums;
using _game.Signals;
using _game.States;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

namespace _game.controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed partial class PlayerController : MonoBehaviour
    {
        #region SelfVariables

        //Serialized
        [Header("Referances")] 
        [SerializeField] public Transform visuals;
        [SerializeField] public Transform effects;
        [SerializeField] public GameObject ship;
        [SerializeField] public PlayerData playerData;

        [Header("Effects")] [SerializeField] private ParticleSystem speedEffect;
        [SerializeField] private GameObject deadEffect;

        //Piravete
        public Rigidbody2D rigidbody2d;

        private GameModeStateMachine stateMachine;

        private bool isDead = true;

        private Dictionary<GameMode, GameModeState> GameModeStates;

        #endregion


        #region UnityMethods


        private void OnEnable()
        {
            Subscire();
        }

        private void OnDisable()
        {
            UnSubscire();
        }

        private void Update()
        {
            if (isDead) return;
            stateMachine.Update();
        }

        private void FixedUpdate()
        {
            if (isDead) return;
            stateMachine.PhysicsUpdate();
        }

        #endregion


        #region MainMethods

        private Vector2 onGetPlayerPosition() => transform.position;

        private void onPlayerDeath()
        {
            isDead = true;
            rigidbody2d.velocity = Vector2.zero;
            rigidbody2d.simulated = false;
            visuals.gameObject.SetActive(false);
            deadEffect.SetActive(true);
            CoreGameSignals.Instance.onChangeSoundState.Invoke(SoundState.dead);
            LevelSignals.Instance.onRestartLevel.Invoke();
        }

        private void OnReset()
        {
            transform.position = LevelSignals.Instance.onGetStartPosition.Invoke();
            visuals.transform.localRotation = quaternion.identity;
            visuals.gameObject.SetActive(true);
            deadEffect.SetActive(false);


            IEnumerator IReset()
            {
                for (int i = 0; i < 5; i++)
                {
                    yield return null;
                }

                rigidbody2d.simulated = true;
                isDead = false;
                IdleSignals.Instance.onPlayerReady.Invoke();
            }

            StartCoroutine(IReset());
        }

        private void OnPlay()
        {
            stateMachine = new GameModeStateMachine(this);

            GameModeStates = new Dictionary<GameMode, GameModeState>()
            {
                { GameMode.cube, stateMachine.CubeState },
                { GameMode.ship, stateMachine.ShipState }
            };
            OnChangeGameMode(GameMode.ship);

            visuals.gameObject.SetActive(true);
            effects.gameObject.SetActive(true);
            isDead = false;
        }

        private void OnFinishLevel()
        {
            rigidbody2d.isKinematic = true;
            rigidbody2d.velocity = Vector2.zero;
            isDead = true;

        }

        private void OnChangeGameMode(GameMode mode)
        {
            stateMachine.ChangeState(GameModeStates[mode]);
        }

        #endregion


        #region SubscireMethods

        private void Subscire()
        {
            IdleSignals.Instance.onGetPlayerPosition += onGetPlayerPosition;
            IdleSignals.Instance.onPlayerDeath += onPlayerDeath;

            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
            CoreGameSignals.Instance.onChangeGameMode += OnChangeGameMode;

            LevelSignals.Instance.onFinishLevel += OnFinishLevel;
        }

        private void UnSubscire()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            IdleSignals.Instance.onGetPlayerPosition -= onGetPlayerPosition;
            IdleSignals.Instance.onPlayerDeath -= onPlayerDeath;
            CoreGameSignals.Instance.onChangeGameMode -= OnChangeGameMode;

            LevelSignals.Instance.onFinishLevel -= OnFinishLevel;
        }

        #endregion
    }
}