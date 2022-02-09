using UnityEngine;

[CreateAssetMenu(fileName = "OnPhysicalHitSoundData", menuName = "ScriptableObjects/OnPhysicalHitSoundData")]
public class OnPhysicalHitSoundData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private float _volumeAmplifier = 2f;
    
    public float VolumeAmplifier => _volumeAmplifier;
}
