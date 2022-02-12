using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class OnPointerDownSound : MonoBehaviour, IPointerDownHandler
{
    [Header("References")]
    [SerializeField] private Transform _transform;

    [Header("Sounds")]
    [SerializeField] private AudioClip[] _audioClips;

    [Header("Preferences")]
    [SerializeField] private float _volume = 0.7f;
    [SerializeField] private float _spatialBlend = 0f;

    [Inject]
    private AudioPooler _audioPooler;

    #region MonoBehaviour

    private void OnValidate()
    {
        _transform = GetComponent<Transform>();
    }

    #endregion

    public void OnPointerDown(PointerEventData eventData)
    {
        PlaySound();
    }

    private void PlaySound()
    {
        _audioPooler.PlayOneShootSound(AudioMixerGroups.SOUND, _audioClips.Random(), _transform.position, 
            _volume, _spatialBlend);
    }
}