using UnityEngine;
using Zenject;

public class OnTriggerEnterParticle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private OnTriggerEnterEvent _onTriggerEnterEvent;
    
    [Header("Data")]
    [SerializeField] private OnTriggerEnterParticleData _data;

    [Inject]
    private ObjectPooler _objectPooler;
    
    #region MonoBehaviour

    private void OnValidate()
    {
        _transform = GetComponent<Transform>();
        _onTriggerEnterEvent = GetComponent<OnTriggerEnterEvent>();
    }

    private void OnEnable()
    {
        _onTriggerEnterEvent.onEnter += SpawnParticle;
    }

    private void OnDisable()
    {
        _onTriggerEnterEvent.onEnter -= SpawnParticle;
    }

    #endregion

    private void SpawnParticle(Collider collider)
    {
        _objectPooler.GetFromPool(_data.ObjectToSpawn,
            collider.ClosestPointOnBounds(_transform.position), Quaternion.identity);
    }
}
