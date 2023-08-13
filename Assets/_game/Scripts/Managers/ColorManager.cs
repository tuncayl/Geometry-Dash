using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    #region SelfVariables

    private Material[] Materials;
    Vector4 baseColor;
    Vector4 offColor;
    Vector4 currentColor;

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

    private void Awake()
    {

    }

    private IEnumerator ColorChange()
    {
        yield return null;
    }
    #endregion



    #region SubscireMethods

    private void Subscire()
    {
        
    }

    private void UnSubscire()
    {
        
    }
    
    #endregion
}
