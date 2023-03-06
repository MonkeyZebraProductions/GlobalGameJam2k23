using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public float cooldown;
    public PowerUp[] powerUps;
    public Transform[] spawnPoints;
    float timer;

    void Start()
    {
        timer = cooldown;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            int rnd = Random.Range(0, powerUps.Length);
            int pos = Random.Range(0, spawnPoints.Length);

            Instantiate(powerUps[rnd], spawnPoints[pos].position, Quaternion.identity);
            timer = cooldown;
        }
    }
}
