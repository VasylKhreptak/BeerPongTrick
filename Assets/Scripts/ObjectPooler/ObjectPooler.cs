using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ObjectPooler : MonoBehaviour
{
    [Serializable]
    private class Pool
    {
        public Pools _poolType;
        public GameObject _prefab;
        public int _size;
        [HideInInspector] public GameObject folder;
    }

    [Header("Pool")]
    private Dictionary<Pools, Queue<GameObject>> _poolDictionary;
    [SerializeField] private List<Pool> _pools;

    private ObjectPooler Instance;

    [Inject] private DiContainer _diContainer;

    #region MonoBehaviour

    private void Awake()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;

        CreatePoolFolders();

        FillPool();
    }

    private void OnDestroy()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    #endregion

    private void CreatePoolFolders()
    {
        foreach (var pool in _pools)
        {
            pool.folder = new GameObject(pool._poolType.ToString());
            pool.folder.transform.parent = gameObject.transform;
        }
    }

    private void FillPool()
    {
        _poolDictionary = new Dictionary<Pools, Queue<GameObject>>();

        for (var i = 0; i < _pools.Count; i++)
        {
            var objectPool = new Queue<GameObject>();

            for (var j = 0; j < _pools[i]._size; j++)
            {
                var obj = _diContainer.InstantiatePrefab(_pools[i]._prefab);
                obj.SetActive(false);

                obj.transform.SetParent(_pools[i].folder.transform);

                objectPool.Enqueue(obj);
            }

            _poolDictionary.Add(_pools[i]._poolType, objectPool);
        }
    }

    public GameObject GetFromPool(Pools pool, Vector3 Position, Quaternion Rotation)
    {
        if (_poolDictionary.ContainsKey(pool) == false)
        {
            Debug.LogWarning("Pool with name " + pool + "doesn't exist");
            return null;
        }

        var objectFromPool = _poolDictionary[pool].Dequeue();

        objectFromPool.transform.position = Position;
        objectFromPool.transform.rotation = Rotation;

        if (objectFromPool.activeSelf)
        {
            objectFromPool.SetActive(false);
        }

        objectFromPool.SetActive(true);

        _poolDictionary[pool].Enqueue(objectFromPool);

        return objectFromPool;
    }

    private void OnSceneUnloaded(Scene scene)
    {
        DisableAllObjects();
    }

    private void DisableAllObjects()
    {
        foreach (Transform poolFolder in transform)
        {
            foreach (Transform poolObjTransform in poolFolder)
            {
                poolObjTransform.gameObject.SetActive(false);
            }
        }
    }
}