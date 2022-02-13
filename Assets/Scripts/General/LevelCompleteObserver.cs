using System;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

using UnityEngine;

public class LevelCompleteObserver : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private OnTriggerEnterEvent _cupTriggerEnterEvent;

    [Header("Additional Conditions")]
    [SerializeField] private LevelCompleteCondition[] _conditions;

    public Action onLevelComplete;

    #region MonoBehaviour

    private void OnEnable()
    {
        _cupTriggerEnterEvent.onEnter += CheckLevelCompletion;
    }

    private void OnDisable()
    {
        _cupTriggerEnterEvent.onEnter -= CheckLevelCompletion;
    }

    #endregion

    private void CheckLevelCompletion(Collider collider)
    {
        if (IsLevelCompleted())
        {
            onLevelComplete?.Invoke();
        }
    }

    private bool IsLevelCompleted()
    {
        foreach (var condition in _conditions)
        {
            if (condition.WasCompleted == false)
            {
                return false;
            }
        }

        return true;
    }

    #region Editor

#if UNITY_EDITOR

    [CustomEditor(typeof(LevelCompleteObserver))]
    public class LevelCompleteObserverEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelCompleteObserver targetScript = (LevelCompleteObserver)target;

            if (GUILayout.Button("Find Conditions"))
            {
                targetScript._conditions = FindObjectsOfType<LevelCompleteCondition>();
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(targetScript);
                EditorSceneManager.MarkSceneDirty(targetScript.gameObject.scene);
            }
        }
    }

#endif

    #endregion
}