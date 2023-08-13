using System;
using System.Collections;
using System.Collections.Generic;
using _game.Signals;
using UnityEngine;

public sealed class CameraFollowController : MonoBehaviour
{
    #region SelfVariables

    //serialize 
    [SerializeField] private Vector3 followOffset;
    [SerializeField] private float followSmoth;

    

    //private 
    private bool isFollow = false;

    private Vector3 positionDiff;

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


    IEnumerator Start()
    {
        positionDiff = (Vector3)IdleSignals.Instance.onGetPlayerPosition.Invoke() - transform.position;

       yield return  null;
    }

    #endregion


    #region MainMethods

    private void LateUpdate()
    {
        if (!isFollow) return;
        transform.position = (Vector3)IdleSignals.Instance.onGetPlayerPosition.Invoke() - positionDiff;

    }


    private void OnPlay()
    {
        isFollow = true;
    }

    private void OnReset()
    {
        transform.position = (Vector3)LevelSignals.Instance.onGetStartPosition.Invoke() - positionDiff;
    }



    #endregion


    #region SubscireMethods

    private void Subscire()
    {
        CoreGameSignals.Instance.onPlay += OnPlay;
        CoreGameSignals.Instance.onReset += OnReset;
    }

    private void UnSubscire()
    {
        CoreGameSignals.Instance.onPlay -= OnPlay;
        CoreGameSignals.Instance.onReset -= OnReset;

    }

    #endregion
}