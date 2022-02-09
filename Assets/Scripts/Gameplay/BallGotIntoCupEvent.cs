using System;
using UnityEngine;

public class BallGotIntoCupEvent : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] private LayerMask _ballLayerMask;

    public Action onLevelComplete;

    #region MonoBehaviour

    private void OnTriggerEnter(Collider other)
    {
        if (IsBall(other))
        {
            onLevelComplete?.Invoke();
        }
    }

    #endregion

    private bool IsBall(Collider collider)
    {
        return _ballLayerMask.ContainsLayer(collider.gameObject.layer);
    }
}