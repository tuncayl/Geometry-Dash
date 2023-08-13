using _game._Extentions;
using _game.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace _game.Signals
{
    public class CoreGameSignals: MonoSingleton<CoreGameSignals>
    {
        public UnityAction onPlay = delegate { };
        public UnityAction onReset = delegate { };
        
        public UnityAction<GameMode> onChangeGameMode=delegate(GameMode arg0) {  };
        
        public  UnityAction<GameObject> onButtonSound=delegate( GameObject arg0) {  };
        
        public  UnityAction<SoundState> onChangeSoundState=delegate(SoundState arg0) {  };


    }
}