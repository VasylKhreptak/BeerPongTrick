using UnityEngine;
using Zenject;

public class OnBallLaunchSound : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BallLauncher _ballLauncher;

    [Header("Sounds")]
    [SerializeField] private AudioClip[] _audioClips;

    [Inject] private AudioPooler _audioPooler;
    [Inject] private BallSpawner _ballSpawner;

    private GameObject _currentBall;
    
    #region MonoBehaviour

    private void OnValidate()
    {
        _ballLauncher = GetComponent<BallLauncher>();
    }

    private void OnEnable()
    {
        _ballLauncher.onBallLaunched += PlaySound;
        _ballSpawner.onBallSpawned += SaveBall;
    }

    private void OnDisable()
    {
        _ballLauncher.onBallLaunched -= PlaySound;
        _ballSpawner.onBallSpawned -= SaveBall;
    }

    #endregion

    private void SaveBall(GameObject ball)
    {
        _currentBall = ball;
    }
    
    private void PlaySound()
    {
        _audioPooler.PlayOneShootSound(AudioMixerGroups.VFX, _audioClips.Random(),
            _currentBall.transform.position, 1f, 1f);
    }
}