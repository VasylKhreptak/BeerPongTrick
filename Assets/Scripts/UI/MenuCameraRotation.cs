using UnityEngine;

public class MenuCameraRotation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;

    [Header("Preferences")]
    [SerializeField] private Vector3 _rotationSpeed;
    [SerializeField] private Space _space = Space.World;

    #region MonoBehaviour

    private void OnValidate()
    {
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        _transform.Rotate(_rotationSpeed, _space);
    }

    #endregion
}