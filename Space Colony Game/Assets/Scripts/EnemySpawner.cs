using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float cooldown;
    public int enemyLimit = 3;
    public Transform[] spawnPoints;

    GameObject[] enemiesAlive;
    float timer;

    void Start()
    {
        timer = cooldown;
    }

    void Update()
    {
        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesAlive.Length < enemyLimit)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
                SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int rnd = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[rnd].position, Quaternion.identity);
        timer = cooldown;
    }
}
