using System;
using UnityEngine;
using Zenject;

public class BallLauncher : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TrajectoryRenderer _trajectory;

    [Header("Launch Preferences")]
    [SerializeField] private float _velocityAmplifier;
    [SerializeField] private float _minVelocity = 0.5f;
    [SerializeField] private float _maxVelocity = 2f;

    [Header("Sensitivity Preferences")]
    [SerializeField] private float _horizontalSensetivity;
    [SerializeField] private float _verticalSensetivity;

    [Inject] private InputManager _inputManager;
    [Inject] private BallSpawner _ballSpawner;

    public bool canShoot = false;

    private GameObject _currentBall;

    public Action onBallLaunched;

    private Transform _cameraTransfrom;

    #region MonoBehaviour

    private void Awake()
    {
        _cameraTransfrom = Camera.main.transform;
    }

    private void OnEnable()
    {
        _ballSpawner.onBallSpawned += OnBallSpawned;
        _inputManager.onEndMove += OnTouchEndMove;
        _inputManager.onMoved += OnMoved;
    }

    private void OnDisable()
    {
        _ballSpawner.onBallSpawned -= OnBallSpawned;
        _inputManager.onEndMove -= OnTouchEndMove;
        _inputManager.onMoved -= OnMoved;
    }

    #endregion

    private void OnBallSpawned(GameObject ball) => _currentBall = ball;

    private void OnTouchEndMove(Vector2 firstPoint, Vector2 lastPoint)
    {
        if (CanLaunchBall())
        {
            LaunchBall(GetDirection(firstPoint, lastPoint), GetVelocity(firstPoint, lastPoint));
        }
    }

    private void LaunchBall(Vector3 direction, float force)
    {
        if (_currentBall.TryGetComponent(out Rigidbody rigidbody) == false) return;

        onBallLaunched?.Invoke();

        EnableMovement(rigidbody);

        _trajectory.Clear();

        rigidbody.velocity = direction * force;

        _currentBall = null;
    }

    private void EnableMovement(Rigidbody rigidbody)
    {
        rigidbody.isKinematic = false;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    private bool CanLaunchBall() => (_currentBall != null && canShoot);

    private Vector3 GetDirection(Vector2 firstPoint, Vector2 lastPoint)
    {
        Vector3 direction = (_currentBall.transform.position - _cameraTransfrom.transform.position);

        direction = Quaternion.AngleAxis((lastPoint.x - firstPoint.x) * _horizontalSensetivity,
            _currentBall.transform.up) * direction;

        direction = Quaternion.AngleAxis((firstPoint.y - lastPoint.y) * _verticalSensetivity,
            _currentBall.transform.right) * direction;

        direction.Normalize();

        return direction;
    }

    private float GetVelocity(Vector2 firstPoint, Vector2 lastPoint)
    {
        return Mathf.Clamp(_velocityAmplifier * Vector2.Distance(firstPoint, lastPoint),
            _minVelocity, _maxVelocity);
    }

    private void OnMoved(Vector2 firstPoint, Vector2 lastPoint)
    {
        if (CanLaunchBall())
        {
            _trajectory.Show(_currentBall.transform.position,
                GetDirection(firstPoint, lastPoint), GetVelocity(firstPoint, lastPoint));
        }
    }
}