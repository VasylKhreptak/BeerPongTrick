using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelLoader : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] private float _delay = 2f;

    [Inject]
    private LevelProvider _levelProvider;
    [Inject]
    private LevelCompleteObserver _levelCompleteObserver;

    private Tween _waitTween;

    #region MonoBehaviour

    private void OnEnable()
    {
        _levelCompleteObserver.onLevelComplete += TryLoadNextLevel;
    }

    private void OnDisable()
    {
        _levelCompleteObserver.onLevelComplete -= TryLoadNextLevel;
        _waitTween.Kill();
    }

    #endregion

    private void TryLoadNextLevel()
    {
        _waitTween = this.DOWait(_delay).OnComplete(() =>
        {
            if (_levelProvider.IsLastLevel())
            {
                SceneManager.LoadScene("MainMenu");
                _levelProvider.MarkCurrentLevelAsCompleted();
                return;
            }
            
            _levelProvider.MarkCurrentLevelAsCompleted();
            SceneManager.LoadScene(_levelProvider.GetNextUnfinishedLevel());
        });
    }
}