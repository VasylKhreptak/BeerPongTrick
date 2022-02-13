using System;
using TMPro;
using UnityEngine;
using Zenject;

public class LevelTextValue : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text _tmp;

    [Inject]
    private LevelProvider _levelProvider;

    #region MonoBehaviour

    private void OnValidate()
    {
        _tmp = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        UpdateText();
    }

    #endregion

    private void UpdateText()
    {
        _tmp.text = _levelProvider.GetCurrentLevelNumber().ToString();
    }
}
