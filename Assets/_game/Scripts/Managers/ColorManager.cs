using System;
using System.Collections;
using System.Collections.Generic;
using _game.Signals;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class ColorManager : MonoBehaviour
{
    #region SelfVariables

    [SerializeField] private Material[] Materials;

    [SerializeField] private Color[] Colors;


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

        StartCoroutine(ChangeRandomColor());
    }

    private IEnumerator ChangeRandomColor()
    {
        yield return new WaitForSeconds(15f);
        Color randomcolor = Colors[Random.Range(0, Colors.Length)];
        for (int i = 0; i < Materials.Length; i++)
        {
            StartCoroutine(ChangeColor(Materials[i],randomcolor,3));
        }

        yield return null;
        StartCoroutine(ChangeRandomColor());
    }
     
    private IEnumerator ChangeColor(Material mat,Color _color,float duration)
    {
        float counter = 0;
        Color _basecolor = mat.GetColor("_Color");
        while (counter < duration) {
            counter += Time.deltaTime;
            mat.color = Color.Lerp (_basecolor, _color, counter / duration);
            yield return null;
        }
        yield return null;
    }


    private void OnFinishLevel()
    {
        for (int i = 0; i < Materials.Length; i++)
        {
            StartCoroutine(ChangeColor(Materials[i], Color.black, 3));
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