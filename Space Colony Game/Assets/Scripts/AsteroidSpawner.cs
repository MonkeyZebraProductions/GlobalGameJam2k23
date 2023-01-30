using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;

    void Start()
    {
        SpawnAsteroid();
    }

    void Update()
    {
        
    }

    IEnumerator SpawnAsteroid()
    {
        yield return new WaitForSeconds(1f);
        SpawnAsteroid();
    }
}
