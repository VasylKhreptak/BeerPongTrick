using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class VibrationToggle : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Toggle _toggle;

        [Header("Player Prefs Preferences")]
        [SerializeField] private string _key = "Vibration";

        #region MonoBehaviour

        private void OnValidate()
        {
            _toggle = GetComponent<Toggle>();
        }

        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(SetVibrationState);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(SetVibrationState);
        }

        #endregion

        private void SetVibrationState(bool state)
        {
            PlayerPrefsSafe.SetBool(_key, state);
        }
    }
}