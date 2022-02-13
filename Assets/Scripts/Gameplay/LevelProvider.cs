using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelProvider : MonoBehaviour
{
    [Header("Levels Data")]
    [Inject] private LevelsData _levelsData;

    public string GetNextUnfinishedLevel()
    {
        foreach (var level in _levelsData.levelContainer.levelItems)
        {
            if (level.finished == false)
            {
                return level.levelName;
            }
        }

        return null;
    }

    public int GetCurrentLevelNumber()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;

        for (var i = 0; i < _levelsData.levelContainer.levelItems.Length; i++)
        {
            var levelItem = _levelsData.levelContainer.levelItems[i];

            if (levelItem.levelName == activeSceneName)
            {
                return i + 1;
            }
        }

        return -1;
    }

    public bool IsLastLevel()
    {
        return GetCurrentLevelNumber() == _levelsData.levelContainer.levelItems.Length;
    }

    public bool FinishedAllLevels()
    {
        foreach (var levelItem in _levelsData.levelContainer.levelItems)
        {
            if (levelItem.finished == false)
            {
                return false;
            }
        }

        return true;
    }

    public void MarkCurrentLevelAsCompleted()
    {
        GetCurrentLevelItem().finished = true;
    }

    public LevelsData.LevelItem GetCurrentLevelItem()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;

        foreach (var levelItem in _levelsData.levelContainer.levelItems)
        {
            if (levelItem.levelName == activeSceneName)
            {
                return levelItem;
            }
        }

        return null;
    }
}