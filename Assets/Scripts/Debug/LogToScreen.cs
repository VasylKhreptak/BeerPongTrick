using System;
using System.Collections;
using System.Globalization;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class LogToScreen : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text _tmp;

    [Header("Preferences")]
    [SerializeField] private float _erasDelay = 4f;


    #region MonoBehaviour

    private void OnValidate()
    {
        _tmp = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        Application.logMessageReceived += ProcessLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= ProcessLog;
    }

    #endregion

    private void ProcessLog(string logString, string stackTrace, LogType type)
    {
        _tmp.text += "\n*  " + logString;
        this.DOWait(_erasDelay).OnComplete(() => { _tmp.text = String.Empty; });
    }
}