using System;
using UnityEngine;

public class OnTriggerEnterEvent : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private OnTriggerEnterEventData _data;

    public Action<Collider> onEnter;

    #region MonoBehaviour

    private void OnTriggerEnter(Collider other)
    {
        if (_data.LayerMask.ContainsLayer(other.gameObject.layer))
        {
            onEnter?.Invoke(other);
        }
    }

    #endregion
}