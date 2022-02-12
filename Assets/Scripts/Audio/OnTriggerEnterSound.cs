using UnityEngine;
using Zenject;

public class OnTriggerEnterSound : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private OnTriggerEnterEvent _onTriggerEnterEvent;

    [Header("Sounds")]
    [SerializeField] private AudioClip[] _audioClips;

    [Inject] private AudioPooler _audioPooler;
    
    #region MonoBehaviour

    private void OnValidate()
    {
        _transform = GetComponent<Transform>();
        _onTriggerEnterEvent = GetComponent<OnTriggerEnterEvent>();
    }

    private void OnEnable()
    {
        _onTriggerEnterEvent.onEnter += PlaySound;
    }


    private void OnDisable()
    {
        _onTriggerEnterEvent.onEnter -= PlaySound;
    }

    #endregion

    private void PlaySound(Collider collider)
    {
        _audioPooler.PlayOneShootSound(AudioMixerGroups.SOUND,
            _audioClips.Random(), collider.ClosestPointOnBounds(_transform.position), 1f, 1f);
    }
}
