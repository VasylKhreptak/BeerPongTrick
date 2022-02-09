using Zenject;

public class InputManagerInstaller : MonoInstaller
{
    [UnityEngine.Header("References")]
    [UnityEngine.SerializeField] private InputManager _inputManager;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_inputManager).AsSingle();
    }
}