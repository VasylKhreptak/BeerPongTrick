using System;
using UnityEngine;
using Zenject;

public class GameCompletionText : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _gameCompleteText;

    [Inject] private LevelProvider _levelProvider;
    
    #region MonoBehaviour

    private void OnValidate()
    {
        _gameCompleteText = gameObject;
    }

    private void OnEnable()
    {
        if (_levelProvider.FinishedAllLevels() == false)
        {
            _gameCompleteText.SetActive(false);
        }
    }

    #endregion
}
