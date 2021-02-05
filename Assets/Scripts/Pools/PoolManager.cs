using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] 
    private PoolParty.PoolInfo[] pools;
    void Awake()
    {
        PoolParty.Init(pools);
    }
}