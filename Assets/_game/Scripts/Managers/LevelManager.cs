using System.Collections;
using _game._Extentions;
using _game.Enums;
using _game.Signals;
using UnityEngine;

namespace _game.managers
{
    public sealed class LevelManager: MonoBehaviour
    {
        #region Self Variables

        //serialzed
        [SerializeField] private Vector2 startPosition;
        [SerializeField] private Vector2 finishPosition;
        
        //private
        

        #endregion


        #region UnityMethods

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

        private Vector2 OnGetStartPosition() => startPosition;

        private float OnGetFinishProgress()
        {
            var playerX = IdleSignals.Instance.onGetPlayerPosition.Invoke().x;
            return  playerX.Remap(startPosition.x,finishPosition.x,0,1);;
        }
        
        private void OnRestartLevel()
        {
            CoreGameSignals.Instance.onChangeGameMode.Invoke(GameMode.cube);
            IEnumerator IRestartLevel()
            {
                yield return new WaitForSeconds(2);
                CoreGameSignals.Instance.onReset.Invoke();
                CoreGameSignals.Instance.onChangeSoundState.Invoke(SoundState.game);

            }

            StartCoroutine(IRestartLevel());
        }
        
        
        #endregion


        #region SubscireMethods

        private void Subscire()
        {
            LevelSignals.Instance.onRestartLevel += OnRestartLevel;

            LevelSignals.Instance.onGetFinishProgress += OnGetFinishProgress;
            LevelSignals.Instance.onGetStartPosition += OnGetStartPosition;
        }

        private void UnSubscire()
        {
            LevelSignals.Instance.onRestartLevel -= OnRestartLevel;
            LevelSignals.Instance.onGetFinishProgress -= OnGetFinishProgress;
            LevelSignals.Instance.onGetStartPosition -= OnGetStartPosition;

        }

        #endregion
    }
}