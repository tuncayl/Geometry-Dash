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


    private void Start()
    {
        positionDiff = (Vector3)IdleSignals.Instance.onGetPlayerPosition.Invoke() - transform.position;

    }

    #endregion


    #region MainMethods

    private void LateUpdate()
    {
        if (!isFollow) return;
        transform.position = (Vector3)IdleSignals.Instance.onGetPlayerPosition.Invoke() - positionDiff;

    }


    private void OnPlay()=> isFollow = true;
    
    private void OnReset()=> transform.position = (Vector3)LevelSignals.Instance.onGetStartPosition.Invoke() - positionDiff;
    
    private void OnChangeSize(float val) => GetComponent<Camera>().orthographicSize = val;


    #endregion


    #region SubscireMethods

    private void Subscire()
    {
        CoreGameSignals.Instance.onPlay += OnPlay;
        CoreGameSignals.Instance.onReset += OnReset;
        IdleSignals.Instance.onChangeCameraSize += OnChangeSize;
    }

    private void UnSubscire()
    {
        CoreGameSignals.Instance.onPlay -= OnPlay;
        CoreGameSignals.Instance.onReset -= OnReset;
        IdleSignals.Instance.onChangeCameraSize -= OnChangeSize;

    }

    #endregion
}