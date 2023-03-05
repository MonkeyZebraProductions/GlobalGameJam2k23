using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public float cooldown;
    public PowerUp[] powerUps;
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

            Instantiate(powerUps[rnd], transform.position, Quaternion.identity);
            timer = cooldown;
        }
    }
}
