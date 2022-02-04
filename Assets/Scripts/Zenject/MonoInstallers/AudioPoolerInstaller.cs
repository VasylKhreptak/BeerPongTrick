using UnityEngine;
using Zenject;

public class AudioPoolerInstaller : MonoInstaller
{
    [Header("References")]
    [SerializeField] private GameObject _audioPoolerPrefab;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_audioPoolerPrefab.GetComponent<AudioPooler>()).AsSingle();
    }
}