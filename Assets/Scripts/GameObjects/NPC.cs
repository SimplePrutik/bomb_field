
using System;
using System.Collections;
using UnityEngine;

public class NPC : PoolObject
{
    private int _health;
    private const int StartHealth = 5;

    public Material healthy;
    public Material damaged;

    private MeshRenderer look => GetComponent<MeshRenderer>();

    private void OnEnable()
    {
        _health = StartHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log($"{transform.name} - HP = {_health}");
        if (_health <= 0)
        {
            StopAllCoroutines();
            ReturnToPool();
        }
        else
        {
            StartCoroutine(GetHurt());
        }
    }

    IEnumerator GetHurt()
    {
        look.material = damaged;
        yield return new WaitForSeconds(0.15f);
        look.material = healthy;
        yield return new WaitForSeconds(0.15f);
        look.material = damaged;
        yield return new WaitForSeconds(0.15f);
        look.material = healthy;
        yield return new WaitForSeconds(0.15f);
        look.material = damaged;
        yield return new WaitForSeconds(0.4f);
        look.material = healthy;
    }
}