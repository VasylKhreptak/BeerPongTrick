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
                Debug.Log(level.levelAsset);

                return level.levelAsset.name;
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

            if (levelItem.levelAsset.name == activeSceneName)
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

            Debug.Log("Finished: " + (levelItem.finished));
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
            if (levelItem.levelAsset.name == activeSceneName)
            {
                return levelItem;
            }
        }

        return null;
    }
}