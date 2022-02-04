using UnityEngine;
using Zenject;

public class ObjectPoolerInstaller : MonoInstaller
{
    [Header("References")]
    [SerializeField] private GameObject _objectPoolerPrefab;

    public override void InstallBindings()
    {
        Container.BindInstance(_objectPoolerPrefab.GetComponent<ObjectPooler>()).AsSingle();
    }
}