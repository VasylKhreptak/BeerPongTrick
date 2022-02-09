using Zenject;

public class GameStatisticInstaller : MonoInstaller
{
    [UnityEngine.Header("References")]
    [UnityEngine.SerializeField] private UnityEngine.GameObject _gameStatisticPrefab;
    
    public override void InstallBindings()
    {
        UnityEngine.GameObject instantiatedObject = Container.InstantiatePrefab(_gameStatisticPrefab);
        instantiatedObject.transform.SetParent(null);
        DontDestroyOnLoad(instantiatedObject);
        
        GameStatistic gameStatistic = instantiatedObject.GetComponent<GameStatistic>();
        
        Container.BindInstance(gameStatistic).AsSingle();
    }
}