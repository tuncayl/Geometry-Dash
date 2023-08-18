using _game.controllers;
using _game.Enums;
using _game.Scripts.Interfaces;
using _game.Signals;
using UnityEngine;

namespace _game.Interacts
{
    public sealed class Portal: MonoBehaviour,IInteractable
    {
        #region SelfVaribles

        [SerializeField] private bool Open;
        

        [SerializeField] private GameObject triggerEffect;
        

        #endregion
        public void Interact()
        {
            triggerEffect.gameObject.SetActive(true);
            CoreGameSignals.Instance.onChangeGameMode.Invoke(Open?GameMode.ship: GameMode.cube);
            IdleSignals.Instance.onChangeCameraSize.Invoke(Open?8:6);

            if (Open is false)  LevelSignals.Instance.onFinishLevel.Invoke();
            
        }
    }
}