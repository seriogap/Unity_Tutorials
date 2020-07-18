using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [Range(0.5f, 10f)]
    [SerializeField] float minSpawnDelay = 1f;
    [Range(0.5f, 10f)]
    [SerializeField] float maxSpawnDelay = 5f;

    [SerializeField] Attacker[] attackersPrefabArray;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnAttacker()
    {
        Attacker attackerToSpawn = attackersPrefabArray[Random.Range(0, attackersPrefabArray.Length)];
        Spawn(attackerToSpawn);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
