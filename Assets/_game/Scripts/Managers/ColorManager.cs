using System;
using System.Collections;
using System.Collections.Generic;
using _game.Signals;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    #region SelfVariables

    [SerializeField] private Material[] Materials;
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
        for (int i = 0; i < Materials.Length; i++)
        {
            Materials[i].SetColor("_Color",Color.blue);
        }
    }
     
    private IEnumerator ColorChange(Material mat,float duration)
    {
        float i = 0;
        float counter = 0;

        Color _basecolor = mat.GetColor("_Color");
   
        while (counter < duration) {
            counter += Time.deltaTime;
            mat.color = Color.Lerp (_basecolor, Color.black, counter / duration);
            yield return null;
        }
        yield return null;
    }


    private void OnFinishLevel()
    {
        for (int i = 0; i < Materials.Length; i++)
        {
            StartCoroutine(ColorChange(Materials[i], 3));
        }
    }
    #endregion


    #region SubscireMethods

    private void Subscire()
    {
        LevelSignals.Instance.onFinishLevel+=OnFinishLevel;
    }

    private void UnSubscire()
    {
        LevelSignals.Instance.onFinishLevel-=OnFinishLevel;

    }

    #endregion
}