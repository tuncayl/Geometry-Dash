using System;
using System.Collections;
using _game.Keys;
using _game.Signals;
using UnityEngine;

namespace _game.managers
{
    public sealed class InputManager : MonoBehaviour
    {
        #region Self Variables

        private bool isInputOpen = true;

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
            InputSignals.Instance.onGetTouchInput.Invoke(HandleTouchInput());
        }

        #endregion


        #region MainMethods

        private TouchInputParams HandleTouchInput()
        {
            if (isInputOpen is false)
                return new TouchInputParams()
                {
                    isTouch = false
                };
            
            if (Input.touchCount == 0)
            {
                return new TouchInputParams()
                {
                    isTouch = Input.GetMouseButton(0)
                };
            }

            Touch touch = Input.GetTouch(0);

            return new TouchInputParams()
            {
                isTouch = TouchIsMove(touch.phase)
            };
        }

        private bool TouchIsMove(TouchPhase phase)
        {
            return phase == TouchPhase.Began || phase == TouchPhase.Stationary || phase == TouchPhase.Moved;
        }


        private void OnPlayerDead()
        {
            isInputOpen = false;
        }

        private void OnPlay()
        {
            IEnumerator WaitSecond()
            {
                for (int i = 0; i < 5; i++)
                {
                    yield return null;
                }

                isInputOpen = true;
            }

            StartCoroutine(WaitSecond());
        }

        private void OnReadyPlayer() => isInputOpen = true;

        #endregion


        #region SubscireMethods

        private void Subscire()
        {
            IdleSignals.Instance.onPlayerDeath += OnPlayerDead;
            IdleSignals.Instance.onPlayerReady += OnReadyPlayer;
            CoreGameSignals.Instance.onPlay += OnPlay;
        }


        private void UnSubscire()
        {
            IdleSignals.Instance.onPlayerDeath -= OnPlayerDead;
            IdleSignals.Instance.onPlayerReady -= OnReadyPlayer;

            CoreGameSignals.Instance.onPlay -= OnPlay;

        }

        #endregion
    }
}