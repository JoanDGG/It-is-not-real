using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool IsAvailable = true;
    public float CooldownDuration = 5f;
    public GameObject[] enemiesPrefab;
    public GameObject[] spawnPositions;
    void Update()
    {
        enemySpawn();
    }
    public void enemySpawn()
    {
        if (IsAvailable == false)
        {
            return;
        }

        GameObject enemy = Instantiate(enemiesPrefab[Random.Range(0, enemiesPrefab.Length)], 
                    spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position, 
                    Quaternion.identity);

        StartCoroutine(StartCooldown());
    }

    public IEnumerator StartCooldown()
     {
         IsAvailable = false;
         yield return new WaitForSeconds(CooldownDuration);
         IsAvailable = true;
     }
}
