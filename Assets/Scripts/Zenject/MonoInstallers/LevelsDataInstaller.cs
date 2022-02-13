using UnityEngine;
using Zenject;

public class LevelsDataInstaller : MonoInstaller
{
    [Header("References")]
    [SerializeField] private GameObject _levelsDataObject;

    public override void InstallBindings()
    {
        GameObject instantiatedObject = Instantiate(_levelsDataObject);
        DontDestroyOnLoad(instantiatedObject);
        Container.BindInstance(instantiatedObject.GetComponent<LevelsData>()).AsSingle();
    }
}