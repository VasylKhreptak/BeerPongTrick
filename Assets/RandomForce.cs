using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class RandomForce : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody _rigidbody;
    
    [Header("Preferences")]
    [SerializeField] private float _force = 10f;
    [SerializeField] private ForceMode _forceMode = ForceMode.Impulse;

    private void OnValidate()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Random.insideUnitCircle.normalized * _force, _forceMode);
        }
    }
}
