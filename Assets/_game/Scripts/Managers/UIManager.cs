using System;
using System.Collections;
using System.Collections.Generic;
using _game.Enums;
using _game.Controllers;
using _game.Signals;
using UnityEngine;
using UnityEngine.UI;


namespace _game.managers
{
    public sealed class UIManager : MonoBehaviour
    {
        #region SelfVariables
        //Serialzefield
        [SerializeField] private List<GameObject> panels;
        
        [Header("Buttons")]
        [SerializeField] private Button soundButton;
        [SerializeField] private Button playButton;

        
        
        //private
        private UIPanelController UIPanelController;
        #endregion


        #region UnityMethods

        private void Awake()
        {
            UIPanelController = new UIPanelController();

        }

        private void OnEnable()
        {
            Subscire();
        }

        private void OnDisable()
        {
            UnSubscire();
        }

        #endregion


        #region MainMethods
        private void OnOpenPanel(UIPanels panelParam)
        {
            UIPanelController.OpenPanel(panelParam , panels);
        }

        private void OnClosePanel(UIPanels panelParam)
        {
            UIPanelController.ClosePanel(panelParam , panels);
        }

        private void OnSoundButtonHandler()
        {
            CoreGameSignals.Instance.onButtonSound.Invoke(soundButton.transform.GetChild(0).gameObject);
        }
        private void OnPlayerButtonHandler()
        {
            CoreGameSignals.Instance.onPlay.Invoke();
          

        }
        private void OnFinishLevel()
        {
            UIPanelController.ClosePanel(UIPanels.gamePanel,panels);
            UIPanelController.OpenPanel(UIPanels.FinishPanel,panels);
        }
        #endregion


        #region SubscireMethods

        private void Subscire()
        {
            LevelSignals.Instance.onFinishLevel += OnFinishLevel;

            
            UISignals.Instance.onOpenPanel += OnOpenPanel;
            soundButton.onClick.AddListener(OnSoundButtonHandler);
            playButton.onClick.AddListener(OnPlayerButtonHandler);

        }

   

        private void UnSubscire()
        {
            LevelSignals.Instance.onFinishLevel -= OnFinishLevel;

            UISignals.Instance.onOpenPanel -= OnClosePanel;
            soundButton.onClick.RemoveListener(OnSoundButtonHandler);
            playButton.onClick.RemoveListener(OnPlayerButtonHandler);

        }

        #endregion
    }
}