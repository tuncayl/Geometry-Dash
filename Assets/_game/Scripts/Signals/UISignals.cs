using _game._Extentions;
using _game.Enums;
using UnityEngine.Events;

namespace _game.Signals
{
    public class UISignals: MonoSingleton<UISignals>
    {
        public UnityAction<UIPanels> onOpenPanel = delegate { };
        public UnityAction<UIPanels> onClosePanel = delegate { };
        
        public  UnityAction<float> onChangeSlider=delegate(float arg0) {  };
    }
}