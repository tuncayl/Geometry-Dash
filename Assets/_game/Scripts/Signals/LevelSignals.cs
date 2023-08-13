using System;
using _game._Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace _game.Signals
{
    public class LevelSignals: MonoSingleton<LevelSignals>
    {
        public UnityAction onRestartLevel = delegate { };
        
        public Func<float> onGetFinishProgress= delegate { return default;};
        
        public  UnityAction onFinishLevel=delegate (){  };
        
        public  Func<Vector2> onGetStartPosition= delegate { return default;};
    }
}