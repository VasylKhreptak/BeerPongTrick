using UnityEngine;

public class StopObjectArea : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] private LayerMask _layerMask;
    
    private void OnTriggerEnter(Collider other)
    {
        if (_layerMask.ContainsLayer(other.gameObject.layer))
        {
            if (other.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.velocity = Vector3.zero;
            }
        }
    }
}
