using System;
using System.Collections.Generic;
using UnityEngine;


public static class PoolParty
{
    
    [Serializable]
    public struct PoolInfo
    {
        public string poolName;
        public PoolObject proto;
        public int count;
        public Pool poolObject;
    }
    
    private static PoolInfo[] pools;

    public static void Init(PoolInfo[] _pools)
    {
        pools = _pools;
        var poolParty = new GameObject();
        poolParty.name = "Pools";
        for (int i = 0; i < pools.Length; i++)
        {
            var pool = new GameObject {name = String.Concat(pools[i].poolName, "Pool") }.AddComponent<Pool>();
            pools[i].poolObject = pool;
            pool.transform.parent = poolParty.transform;
            pool.Init(pools[i].proto, pools[i].count);
        }
    }

    public static GameObject GetObject(string objName)
    {
        if (pools != null) {
            for (int i = 0; i < pools.Length; i++) {
                if (string.Compare(pools [i].poolName, objName) == 0) { 
                    var result = pools[i].poolObject.GetObject().gameObject;
                    result.SetActive (true);
                    return result;
                }
            }
        } 
        return null;
    }
}