using System;
using _game._Extentions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace _game.Signals
{
    public class IdleSignals : MonoSingleton<IdleSignals>
    {
        #region Player

        public Func<Vector2> onGetPlayerPosition = delegate() { return default; };
        
        public UnityAction onPlayerDeath = delegate {  };

        public  UnityAction onPlayerReady=delegate {  };
        #endregion

        #region Camera
        public UnityAction<float> onChangeCameraSize=delegate {  };
        

        #endregion

    

  
    }
}