using System;
using UnityEngine;

public class TrailRendererCleaner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TrailRenderer _trailRenderer;

    #region MonoBehaviour

    private void OnValidate()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void OnEnable()
    {
        _trailRenderer.Clear();
    }

    #endregion
}
