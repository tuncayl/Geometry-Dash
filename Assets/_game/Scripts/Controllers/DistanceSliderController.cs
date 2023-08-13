using System;
using _game.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace _game.Controllers
{
    [RequireComponent(typeof(Slider))]
    public sealed class DistanceSliderController: MonoBehaviour
    {
        #region SelfVariables

        //private
        private Slider slider;
        
        

        #endregion

        #region UnityMethods

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        private void Update()
        {
            slider.value = LevelSignals.Instance.onGetFinishProgress.Invoke();
        }

        #endregion
    }
}