using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Pool
{
    private Transform poolParent;
    List<GameObject> itemPool;

    public Pool(Transform _poolParent)
    {
        poolParent = _poolParent;
    }

    public List<GameObject> ItemPool
    {
        get
        {
            if (itemPool == null)
                itemPool = new List<GameObject>();
            return itemPool;
        }
    }

    public Transform PoolParent
    {
        get
        {
            return poolParent;
        }

        set
        {
            poolParent = value;
        }
    }
}

[System.Serializable]
public class PoolLeader
{
    public PoolName poolName;
    Transform poolParent;
    [SerializeField]
    List<GameObject> prefabs;


    [SerializeField]
    int poolSize;
    List<Pool> subPools;

    public Transform PoolParent
    {
        get
        {
            return poolParent;
        }

        set
        {
            poolParent = value;
        }
    }


    public void InitializePool()
    {
        if (prefabs == null || prefabs.Count == 0)
        {
            Debug.LogWarning("Cannot initialize pool " + poolParent.name + " because no prefabs are linked.");
            return;
        }

        if (poolSize <= 0)
        {
            Debug.LogWarning("Cannot initialize pool because pool size is null or negative.");
            return;
        }

        for (int i = 0; i < prefabs.Count; i++)
        {
            if (poolParent.childCount <= i)
            {
                GameObject poolContainer = new GameObject("Pool Container " + i);
                poolContainer.transform.parent = poolParent;
            }

            subPools.Add(new Pool(poolParent.GetChild(i)));
            for (int j = 0; j < poolSize; j++)
            {
                CreateRandomPoolItem(i);
            }
        }
    }

    GameObject CreateRandomPoolItem(int _subpoolIndex)
    {
        int prefabIndex = Random.Range(0, prefabs.Count);
        GameObject item = GameObject.Instantiate(prefabs[prefabIndex], poolParent.GetChild(_subpoolIndex));
        item.AddComponent<PoolChild>().pool = subPools[_subpoolIndex];
        item.SetActive(false);
        subPools[_subpoolIndex].ItemPool.Add(item);
        return item;
    }
}

public enum PoolName { redToken, blueToken, yellowToken, greenToken, blackToken, powerToken }

public class PoolManager : MonoBehaviour {


    [SerializeField]
    List<PoolLeader> poolLeaders;

    public PoolLeader GetPoolByName(PoolName _poolName, int _poolIndex = 0)
    {
        int iteration = 0;
        foreach(PoolLeader leader in poolLeaders)
        {
            if(leader.poolName == _poolName)
            {
                if (iteration == _poolIndex)
                    return leader;
                else
                    iteration++;
            }
        }
        return null;
    }

	// Use this for initialization
	void Start ()
    {
        if (poolLeaders == null || poolLeaders.Count == 0)
        {
            Debug.LogWarning("There are no pool leaders defined in Pool Manager.");
            return;
        }

        foreach (PoolLeader leader in poolLeaders)
        {
            GameObject poolParent = new GameObject(leader.poolName.ToString());
            poolParent.transform.SetParent(transform);
            leader.PoolParent = poolParent.transform;
            leader.InitializePool();
        }
    }
}
