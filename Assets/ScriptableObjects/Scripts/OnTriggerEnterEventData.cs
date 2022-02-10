using UnityEngine;

[CreateAssetMenu(fileName = "OnTriggerEnterEventData", menuName = "ScriptableObjects/OnTriggerEnterEventData")]
public class OnTriggerEnterEventData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private LayerMask _layerMask;
    
    public LayerMask LayerMask => _layerMask;
}
