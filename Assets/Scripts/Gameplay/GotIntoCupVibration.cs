using MoreMountains.NiceVibrations;
using UnityEngine;

public class GotIntoCupVibration : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GotIntoCupEvent _gotIntoCupEvent;

    [Header("Vibration Preferences")]
    [SerializeField] private HapticTypes _hapticType = HapticTypes.LightImpact;

    #region MonoBehaviour

    private void OnValidate()
    {
        _gotIntoCupEvent = GetComponent<GotIntoCupEvent>();
    }

    private void OnEnable()
    {
        _gotIntoCupEvent.onGotIntoCup += Vibrate;
    }

    private void OnDisable()
    {
        _gotIntoCupEvent.onGotIntoCup -= Vibrate;
    }

    #endregion

    private void Vibrate()
    {
        MMVibrationManager.Haptic(_hapticType);
    }
}