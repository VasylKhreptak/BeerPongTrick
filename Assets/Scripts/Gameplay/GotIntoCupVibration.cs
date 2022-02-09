using System;
using UnityEngine;

public class GotIntoCupVibration : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GotIntoCupEvent _gotIntoCupEvent;

    #region MonoBehaviour

    private void OnValidate()
    {
        _gotIntoCupEvent = GetComponent<GotIntoCupEvent>();
    }

    private void OnEnable()
    {
        _gotIntoCupEvent.onGotIntoCup += Vibrate;
    }

    private void OnDisable()
    {
        _gotIntoCupEvent.onGotIntoCup -= Vibrate;
    }

    #endregion

    private void Vibrate()
    {
    }
}