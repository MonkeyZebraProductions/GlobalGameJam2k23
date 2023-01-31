using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float cooldown = 5f;
    public Transform[] spawnPoints;

    void Start()
    {
        StartCoroutine(SpawnAsteroid());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnAsteroid()
    {
        int rnd = Random.Range(0, spawnPoints.Length);
        Vector2 direction = spawnPoints[rnd].position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float rndAngle = Random.Range(angle + 60f, angle + 120f);
        Quaternion rotation = Quaternion.Euler(0f, 0f, rndAngle);

        Instantiate(asteroidPrefab, spawnPoints[rnd].position, rotation);
        yield return new WaitForSeconds(cooldown);
        StartCoroutine(SpawnAsteroid());
    }
}
