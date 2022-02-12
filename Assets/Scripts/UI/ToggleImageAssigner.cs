using System;
using UnityEngine;
using UnityEngine.UI;

public class ToggleImageAssigner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image _image;
    [SerializeField] private Toggle _toggle;

    [Header("Preferences")]
    [SerializeField] private Sprite _enabled;
    [SerializeField] private Sprite _disabled;

    [Header("Player Prefs Preferences")]
    [SerializeField] private string _key;

    #region MonoBahaviour

    private void Start()
    {
        bool toggleIsOn = PlayerPrefsSafe.GetBool(_key, true);
        
        SetImageState(toggleIsOn);
        _toggle.isOn = toggleIsOn;
    }

    private void OnValidate()
    {
        _image = GetComponent<Image>();
        _toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(SetImageState);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(SetImageState);
    }

    private void OnDestroy()
    {
        PlayerPrefsSafe.SetBool(_key, _toggle.isOn);
    }

    #endregion

    private void SetImageState(bool value)
    {
        _image.sprite = value ? _enabled : _disabled;
    }
}