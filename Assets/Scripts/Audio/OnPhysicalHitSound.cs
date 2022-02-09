using UnityEngine;
using Zenject;

public class OnPhysicalHitSound : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private OnPhysicalHitSoundData _data;

    [Header("Sounds")]
    [SerializeField] private AudioClip[] _audioClips;

    [Inject] private AudioPooler _audioPooler;

    #region MonoBehaviour

    private void OnCollisionEnter(Collision collision)
    {
        if (CanPlaySound(collision))
        {
            PlaySound(collision);
        }
    }

    #endregion

    private bool CanPlaySound(Collision collision)
    {
        return _data.LayerMask.ContainsLayer(collision.gameObject.layer);
    }

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