using System;
using UnityEngine;

public class GotIntoCupEvent : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] private LayerMask _layerMask;

    public Action onGotIntoCup;

    #region MonoBehaviour

    private void OnTriggerEnter(Collider other)
    {
        if (_layerMask.ContainsLayer(other.gameObject.layer))
        {
            onGotIntoCup?.Invoke();
        }
    }

    #endregion
}