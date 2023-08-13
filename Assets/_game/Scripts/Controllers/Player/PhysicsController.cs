using System;
using System.Collections;
using _game._Extentions;
using _game.Scripts.Interfaces;
using Unity.Mathematics;
using UnityEngine;

namespace _game.controllers
{
    public sealed partial class PlayerController : MonoBehaviour
    {


        #region SelfVariables
        

        #endregion

        #region MainMethods

        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.TryGetComponent<IInteractable>(out IInteractable Interactble))
                Interactble.Interact();

            if (col.transform.CompareTag("Ground"))
            {
                speedEffect.Play();
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.TryGetComponent<IInteractable>(out IInteractable Interactble))
                Interactble.Interact();
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.transform.CompareTag("Ground"))
            {
                speedEffect.Stop();
            }
        }


        #endregion
    }
}