using UnityEngine;

[CreateAssetMenu(fileName = "OnPhysicalHitSoundData", menuName = "ScriptableObjects/OnPhysicalHitSoundData")]
public class OnPhysicalHitSoundData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private float _volumeAmplifier = 2f;

    [Header("LayerMask")]
    [SerializeField] private LayerMask _layerMask;

    public LayerMask LayerMask => _layerMask;
    public float VolumeAmplifier => _volumeAmplifier;
}
