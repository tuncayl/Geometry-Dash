using _game.controllers;
using _game.Enums;
using _game.Scripts.Interfaces;
using _game.Signals;
using UnityEngine;

namespace _game.Interacts
{
    public sealed class Obstacle : MonoBehaviour,IInteractable
    {
        
        public void Interact()
        {
            IdleSignals.Instance.onPlayerDeath.Invoke();
        }
    }
}