using UnityEngine;

public class GameFramerate : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] private int _defaultFramerate = 60;

    [Header("PlayerPrefs Preferences")]
    [SerializeField] private string _key = "GameFramerate";

    private void Start()
    {
        SetFramerate(PlayerPrefsSafe.GetInt(_key, _defaultFramerate));
        
        QualitySettings.vSyncCount = 0;
    }

    private void SetFramerate(int framerate)
    {
        Application.targetFrameRate = framerate;
    }
}
