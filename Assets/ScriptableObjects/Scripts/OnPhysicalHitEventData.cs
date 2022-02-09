using UnityEngine;

[CreateAssetMenu(fileName = "OnPhysicalHitEventData", menuName = "ScriptableObjects/OnPhysicalHitEvent")]
public class OnPhysicalHitEventData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private LayerMask _layerMask;
    
    public LayerMask LayerMask => _layerMask;
}
