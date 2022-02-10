using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class BallSpawner : MonoBehaviour
{
    [Header("Spawn Preferences")]
    [SerializeField] private Pools _ballPool;
    [SerializeField] private Transform _spawnPlace;
    [SerializeField] private float _spawnDelay = 3f;
    [SerializeField] private float _startSpawnDelay = 2f;

    [Inject] private ObjectPooler _objectPooler;
    [Inject] private BallLauncher _ballLauncher;
    
    private Tween _waitTween;

    public  Action<GameObject> onBallSpawned;

    private Transform _cameraTransform;
    
    #region Monobehaviour

    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
        
        SpawnBall(_startSpawnDelay);
    }

    private void OnEnable()
    {
        _ballLauncher.onBallLaunched += RespawnBall;
    }

    private void OnDisable()
    {
        _ballLauncher.onBallLaunched -= RespawnBall;
    }

    private void OnDestroy()
    {
        _waitTween.Kill();
    }

    #endregion

    private void SpawnBall()
    {
        GameObject ball = _objectPooler.GetFromPool(_ballPool, _spawnPlace.position,
            Quaternion.LookRotation(_spawnPlace.position - _cameraTransform.position).normalized);
        
        DisableMovement(ball);
        
        onBallSpawned?.Invoke(ball);
    }

    private void DisableMovement(GameObject ball)
    {
        if (ball.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
            rigidbody.isKinematic = true;
        }
    }

    private void SpawnBall(float delay)
    {
        _waitTween.Kill();
        this.DOWait(delay).OnComplete(SpawnBall);
    }

    private void RespawnBall() => SpawnBall(_spawnDelay);
}