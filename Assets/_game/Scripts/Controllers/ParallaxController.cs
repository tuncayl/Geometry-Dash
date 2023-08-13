using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ParallaxController : MonoBehaviour
{
    #region SelfVariables

    //serializefield
    
    [SerializeField] private Material parallaxMaterial;

    [Range(-10, 10)] [SerializeField] private float paralaxSpeed;

    [SerializeField] private bool parallaxAxisX = false, parallaxAxisY = false;
    
    //private 
    private Transform cameraTransform;
    private Vector3 cameraStartPosition;
    private Vector3 cameraOffset;

    private float distance;

    #endregion


    #region UnityMethods

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        cameraStartPosition = cameraTransform.position;
        cameraOffset = cameraStartPosition - transform.position;
    }

    private void LateUpdate()
    {
        distance = cameraTransform.position.x - cameraStartPosition.x;
        transform.position = new Vector3(parallaxAxisX?cameraTransform.position.x+cameraOffset.x: transform.position.x,
            parallaxAxisY?cameraTransform.position.y-cameraOffset.y :transform.position.y);
        parallaxMaterial.SetTextureOffset("_MainTex",new Vector2( -distance,0)*paralaxSpeed);
    }

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