using System;
using UnityEngine;

public class OnPhysicalHitEvent : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private OnPhysicalHitEventData _data;

    public Action<Collision> onHit;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (_data.LayerMask.ContainsLayer(collision.gameObject.layer))
        {
            onHit?.Invoke(collision);
        }
    }
}
