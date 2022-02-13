using System;
using UnityEditor;
using UnityEngine;

public class LevelsData : MonoBehaviour
{
    [Header("Data")]
    public LevelContainer levelContainer;

    [Header("Player Prefs Preferences")]
    [SerializeField] private string _key = "Levels";

    #region MonoBehaviour

    private void OnEnable()
    {
        Load();
    }

    private void OnDisable()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    #endregion


    [ContextMenu("Load")]
    private void Load()
    {
        if (GameDataProvider.HasKey(_key))
        {
            levelContainer = GameDataProvider.Load<LevelContainer>(_key);
        }
    }

    [ContextMenu("Save")]
    private void Save()
    {
        GameDataProvider.Save(_key, levelContainer);
    }

    [Serializable]
    public class LevelContainer
    {
        public LevelItem[] levelItems;
    }
    
    [Serializable]
    public class LevelItem
    { 
        [Scene] public string levelName;
        public bool finished;
    }
}
