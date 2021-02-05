using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSpawner : Spawner
{
    public List<Spawner> spawnZones;
    public float spawnRate;
    
    private void Awake()
    {
        StartCoroutine(ProcessSpawn());
    }

    IEnumerator ProcessSpawn()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(60 / spawnRate);
        }
    }
    
    public override void Spawn()
    {
        spawnZones[Random.Range(0, spawnZones.Count)].Spawn();
    }
}