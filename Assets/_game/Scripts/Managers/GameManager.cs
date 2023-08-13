using System;
using _game._Extentions;
using _game.Signals;
using UnityEngine;

namespace _game.managers
{
    public  class GameManager: MonoBehaviour
    {
        #region SelfVariables


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

        private void Awake()
        {
            Application.targetFrameRate = 60;

        }

        #endregion


        #region MainMethods



        #endregion


        #region SubscireMethods

        private void Subscire()
        {
        }

        private void UnSubscire()
        {
        }

        #endregion
    }
}