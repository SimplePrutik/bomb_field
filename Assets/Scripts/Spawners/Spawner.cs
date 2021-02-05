using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public BoxCollider spawnZone;

    public string spawnObject;

    public virtual void Spawn()
    {
        var npc = PoolParty.GetObject(spawnObject);
        npc.transform.position = GetRandomSpawnPoint();
    }

    private Vector3 GetRandomSpawnPoint()
    {
        return spawnZone.transform.position + new Vector3(
                   Random.Range(-spawnZone.bounds.extents.x, spawnZone.bounds.extents.x),
                   0,
                   Random.Range(-spawnZone.bounds.extents.z, spawnZone.bounds.extents.z));
    }
}