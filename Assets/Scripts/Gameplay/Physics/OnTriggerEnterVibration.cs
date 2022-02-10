using MoreMountains.NiceVibrations;
using UnityEngine;

public class OnTriggerEnterVibration : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private OnTriggerEnterEvent _onTriggerEnterEvent;

    [Header("Vibration Preferences")]
    [SerializeField] private HapticTypes _hapticType = HapticTypes.LightImpact;

    #region MonoBehaviour

    private void OnValidate()
    {
        _onTriggerEnterEvent = GetComponent<OnTriggerEnterEvent>();
    }

    private void OnEnable()
    {
        _onTriggerEnterEvent.onEnter += Vibrate;
    }

    private void OnDisable()
    {
        _onTriggerEnterEvent.onEnter -= Vibrate;
    }

    #endregion

    private void Vibrate(Collider collider)
    {
        MMVibrationManager.Haptic(_hapticType);
    }
}