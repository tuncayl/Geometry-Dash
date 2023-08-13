using System;
using _game._Extentions;
using _game.Keys;
using UnityEngine.Events;

namespace _game.Signals
{
    public class InputSignals: MonoSingleton<InputSignals>
    {
        public UnityAction<TouchInputParams> onGetTouchInput = delegate(TouchInputParams arg0) { };
    }
}