using UnityEngine;

[CreateAssetMenu(fileName = "OnTriggerEnterParticleData", 
    menuName = "ScriptableObjects/OnTriggerEnterParticleData")]
public class OnTriggerEnterParticleData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private Pools _objectToSpawn = Pools.BeerSplashParticle;

    public Pools ObjectToSpawn => _objectToSpawn;
}
