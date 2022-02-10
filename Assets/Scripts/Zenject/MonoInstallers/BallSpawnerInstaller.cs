using Zenject;

public class BallSpawnerInstaller : MonoInstaller
{
    [UnityEngine.Header("Referencs")]
    [UnityEngine.SerializeField]
    private BallSpawner _ballSpawner;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_ballSpawner).AsSingle();
    }
}