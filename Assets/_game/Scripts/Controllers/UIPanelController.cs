using System.Collections.Generic;
using _game.Enums;
using UnityEngine;

namespace _game.Controllers
{
    public sealed class UIPanelController
    {
        public void OpenPanel(UIPanels panelParam,List<GameObject> panels)
        {
            panels[(int) panelParam].SetActive(true);
        }

        public void ClosePanel(UIPanels panelParam,List<GameObject> panels)
        {
            panels[(int) panelParam].SetActive(false);
        }
    }
}