using MoreMountains.NiceVibrations;
using UnityEngine;

public class OnTriggerEnterVibration : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private OnTriggerEnterEvent _onTriggerEnterEvent;

    [Header("Vibration Preferences")]
    [SerializeField] private HapticTypes _hapticType = HapticTypes.LightImpact;

    [Header("Player Prefs Preferences")]
    [SerializeField] private string _key = "Vibration";

    #region MonoBehaviour

    private void OnValidate()
    {
        _onTriggerEnterEvent = GetComponent<OnTriggerEnterEvent>();
    }

    private void OnEnable()
    {
        _onTriggerEnterEvent.onEnter += TryVibrate;
    }

    private void OnDisable()
    {
        _onTriggerEnterEvent.onEnter -= TryVibrate;
    }

    #endregion

    private void TryVibrate(Collider collider)
    {
        if (CanVibrate())
        {
            MMVibrationManager.Haptic(_hapticType);
        }
    }

    private bool CanVibrate()
    {
        return PlayerPrefsSafe.GetBool(_key, true);
    }
}