using System;
using UnityEngine;

public class OnCollisionEnterEvent : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private OnPhysicalHitEventData _data;

    public Action<Collision> onCollision;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (_data.LayerMask.ContainsLayer(collision.gameObject.layer))
        {
            onCollision?.Invoke(collision);
        }
    }
}
