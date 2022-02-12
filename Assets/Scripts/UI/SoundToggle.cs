using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class SoundToggle : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private Toggle _toggle;

        [Header("Preferences")]
        [SerializeField] private AudioMixerGroup _audioMixerGroup;

        [Header("Player Prefs Settings")]
        [SerializeField] private string _key;

        #region MonoBahaviour

        private void Start()
        {
            bool isOn = PlayerPrefsSafe.GetBool(_key, true);
            
            SetVolume(isOn);
            _toggle.isOn = isOn;
        }

        private void OnValidate()
        {
            _toggle = GetComponent<Toggle>();
        }

        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(SetVolume);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(SetVolume);
        }

        private void OnDestroy()
        {
            PlayerPrefsSafe.SetBool(_key, _toggle.isOn);
        }

        #endregion

        private void SetVolume(bool isOn)
        {
            _audioMixer.SetFloat(_audioMixerGroup.name, isOn ? 0 : -80);
        }
    }
}