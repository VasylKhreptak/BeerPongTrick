using Zenject;

public class LevelProviderInstaller : MonoInstaller
{
    [UnityEngine.Header("References")]
    [UnityEngine.SerializeField]
    private LevelProvider _levelProvider;
    public override void InstallBindings()
    {
        Container.BindInstance(_levelProvider).AsSingle();
    }
}