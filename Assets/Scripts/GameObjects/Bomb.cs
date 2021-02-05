using System;
using System.Collections;
using UnityEngine;

public class Bomb : PoolObject
{
    public int damage;
    public int blastRadius;

    public void DealDamage()
    {
        var enemiesHit = Physics.OverlapSphere(transform.localPosition, blastRadius);
        foreach (var enemy in enemiesHit)
        {
            var npc = enemy.GetComponent<NPC>();
            if (npc == null)
                continue;
            if (Physics.Linecast(transform.position, npc.transform.position, out var hitInfo))
            {
                if (hitInfo.collider.GetComponent<Wall>() != null)
                    continue;
            }
            npc.TakeDamage(damage);
        }
        ReturnToPool();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Floor>() != null)
            DealDamage();
    }
}