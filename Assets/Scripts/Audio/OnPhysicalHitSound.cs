using System;
using UnityEngine;
using Zenject;

public class OnPhysicalHitSound : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private OnPhysicalHitEvent _onPhysicalHitEvent;
    
    [Header("Data")]
    [SerializeField] private OnPhysicalHitSoundData _data;

    [Header("Sounds")]
    [SerializeField] private AudioClip[] _audioClips;

    [Inject] private AudioPooler _audioPooler;

    #region MonoBehaviour

    private void OnValidate()
    {
        _onPhysicalHitEvent = GetComponent<OnPhysicalHitEvent>();
    }

    private void OnEnable()
    {
        _onPhysicalHitEvent.onHit += PlaySound;
    }

    private void OnDisable()
    {
        _onPhysicalHitEvent.onHit -= PlaySound;
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlaySound(collision);
    }

    #endregion

    private void PlaySound(Collision collision)
    {
        _audioPooler.PlayOneShootSound(AudioMixerGroups.VFX,
            _audioClips.Random(), collision.GetContact(0).point, GetVolume(collision), 1f);
    }

    private float GetVolume(Collision collision)
    {
        return collision.impulse.magnitude * _data.VolumeAmplifier;
    }
}