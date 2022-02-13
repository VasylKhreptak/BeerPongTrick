using Zenject;

public class LevelCompleteObserverInstaller : MonoInstaller
{
    [UnityEngine.Header("References")]
    [UnityEngine.SerializeField]
    private LevelCompleteObserver _levelCompleteObserver;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_levelCompleteObserver).AsSingle();
    }
}