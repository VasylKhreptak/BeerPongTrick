using UnityEngine;
using Zenject;

public class LevelCompleteCondition : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private OnCollisionEnterEvent _collisionEvent;

    private bool _wasCompleted;

    public bool WasCompleted => _wasCompleted;

    [Inject] private BallLauncher _ballLauncher;
    
    #region MonoBehaviour

    private void OnValidate()
    {
        _collisionEvent = GetComponent<OnCollisionEnterEvent>();
    }

    private void OnEnable()
    {
        _collisionEvent.onCollision += OnCollision;
        _ballLauncher.onBallLaunched += ResetState;
    }

    private void OnDisable()
    {
        _collisionEvent.onCollision -= OnCollision;
        _ballLauncher.onBallLaunched -= ResetState;
    }

    #endregion

    private void OnCollision(Collision collision)
    {
        _wasCompleted = true;
    }

    private void ResetState()
    {
        _wasCompleted = false;
    }
}
