using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float cooldown;
    public float limitCooldown = 60f;
    public int enemyLimit = 3;
    public int minAmountOfEnemiesSpawned = 1, maxAmountOfEnemiesSpawned = 3;
    public Transform[] spawnPoints;

    GameObject[] enemiesAlive;
    float timer, lc;

    void Start()
    {
        timer = cooldown;
        lc = limitCooldown;
    }

    void Update()
    {
        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesAlive.Length < enemyLimit)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                int rnd = Random.Range(minAmountOfEnemiesSpawned, maxAmountOfEnemiesSpawned + 1);

                if((rnd + enemiesAlive.Length) > enemyLimit)
                {
                    int overlap = (rnd + enemiesAlive.Length) - enemyLimit;
                    rnd = overlap;
                }

                for (int i = 0; i < rnd; i++)
                {
                    SpawnEnemy();
                }
            }
        }

        IncreaseLimit();
    }

    void SpawnEnemy()
    {
        int rnd = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[rnd].position, Quaternion.identity);
        timer = cooldown;
    }

    void IncreaseLimit()
    {
        lc -= Time.deltaTime;

        if(lc <= 0f)
        {
            enemyLimit++;
            lc = limitCooldown;
        }
    }
}
