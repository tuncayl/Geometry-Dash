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
        // [SerializeField] private Vector2 rightSize;
        // [SerializeField] private Vector2 rightOffset;

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

        private void OnDrawGizmosSelected()
        {
            // Gizmos.matrix = transform.localToWorldMatrix;
            // Gizmos.DrawWireCube(Vector3.zero+(Vector3)rightOffset, rightSize);
            // Gizmos.DrawWireCube(Vector3.zero+(Vector3)new Vector2(-0.00249f, 0.474f), new Vector2(0.93f, 0.039f));

        }

        #endregion
    }
}