using Zenject;

public class BallLauncherInstaller : MonoInstaller
{
    [UnityEngine.Header("References")]
    [UnityEngine.SerializeField] private BallLauncher _ballLauncher; 
        
    public override void InstallBindings()
    {
        Container.BindInstance(_ballLauncher).AsSingle();
    }
}