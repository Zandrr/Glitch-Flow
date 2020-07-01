using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackersPrefab;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 3f;

    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = UnityEngine.Random.Range(0, attackersPrefab.Length);
        Spawn(attackersPrefab[attackerIndex]);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker,
            transform.position, transform.rotation) as Attacker;

        newAttacker.transform.parent = transform;
    }



}
