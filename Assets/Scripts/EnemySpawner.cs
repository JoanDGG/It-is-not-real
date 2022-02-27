using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    private bool IsAvailable = true;
    public float CooldownDuration = 5f;
    public GameObject[] enemiesPrefab;
    public GameObject[] spawnPositions;

    public int actualWave = 1;
    public int enemies2NextWave = 3;

    void Update()
    {
        if(enemies2NextWave <= 0)
        {
            actualWave += 1;
            enemies2NextWave = actualWave * 15;
            GameObject.Find("WaveText").GetComponent<Text>().text = "Wave " + actualWave;
            GameObject.Find("Player").GetComponent<HealthPoints>().hp *= 1.25f;
            if (GameObject.Find("Player").GetComponent<HealthPoints>().hp >= 100)
            {
                GameObject.Find("Player").GetComponent<HealthPoints>().hp = 100;
            }
        }
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
        yield return new WaitForSeconds(CooldownDuration);
        enemySpawn();
    }
}
