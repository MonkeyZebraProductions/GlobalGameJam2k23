using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
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
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle + 90f);
        Instantiate(asteroidPrefab, spawnPoints[rnd].position, rotation);
        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnAsteroid());
    }
}
