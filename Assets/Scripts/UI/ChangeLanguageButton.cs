using System;
using I2.Loc;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ChangeLanguageButton : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Button _button;

        [Header("Preferences")]
        [SerializeField] private LanguageContainer _languageContainer;

        [Header("Player Prefs Preferences")]
        [SerializeField] private string _key;

        private LanguageItem _currentLanguageItem;
        
        #region MonoBehaviour

        private void Awake()
        {
            LoadData();
        }

        private void OnValidate()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnDestroy()
        {
            SaveData();
        }

        private void OnApplicationPause(bool hasFocus)
        {
            if (hasFocus)
            {
                SaveData();
            }
        }

        #endregion

        private void SaveData()
        {
            GameDataProvider.Save(_key, _currentLanguageItem);
        }

        private void LoadData()
        {
            if (GameDataProvider.HasKey(_key))
            {
                LanguageItem languageItem = GameDataProvider.Load<LanguageItem>(_key);
                
                SetButtonSprite(languageItem.sprite);
                _currentLanguageItem = languageItem;
                
                return;
            }

            _currentLanguageItem = _languageContainer.languageItems[0];
        }
        
        private void OnButtonClick()
        {
            _currentLanguageItem = _languageContainer.languageItems.GetNext(_currentLanguageItem);

            SetButtonSprite(_currentLanguageItem.sprite);
            TrySetLanguage(_currentLanguageItem.languageName);
        }

        private void SetButtonSprite(Sprite sprite)
        {
            _button.image.sprite = sprite;
        }
        
        private void TrySetLanguage(string language)
        {
            if (CanSetLanguage(language))
            {
                LocalizationManager.CurrentLanguage = language;
            }
        }

        private bool CanSetLanguage(string language)
        {
            return LocalizationManager.HasLanguage(language);
        }

        [System.Serializable]
        public class LanguageContainer
        {
            public LanguageItem[] languageItems;
        }
        
        [System.Serializable]
        public class LanguageItem
        {
            public string languageName;
            public Sprite sprite;
        }
    }
}