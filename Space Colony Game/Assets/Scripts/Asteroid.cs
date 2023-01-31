using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public enum Size { big, medium, small}
    public Size size;

    AsteroidSpawner asteroidSpawner;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        asteroidSpawner = GameObject.FindGameObjectWithTag("AS").GetComponent<AsteroidSpawner>();

        rb.AddForce(transform.up * 5f, ForceMode2D.Impulse);
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        
    }

    public void Die()
    {
        if(size == Size.big)
        {
            AsteroidShatter(asteroidSpawner.mediumAsteroid);
            AsteroidShatter(asteroidSpawner.mediumAsteroid);
        }

        else if(size == Size.medium)
        {
            AsteroidShatter(asteroidSpawner.smallAsteroid);
            AsteroidShatter(asteroidSpawner.smallAsteroid);
        }

        Destroy(gameObject);
    }

    void AsteroidShatter(GameObject asteroidSize)
    {
        float rndAngle = Random.Range(0f, 360f);
        Quaternion rotation = Quaternion.Euler(0f, 0f, rndAngle);
        GameObject go = asteroidSize;
        Instantiate(go, transform.position, rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(1);
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Asteroid"))
        {
            /*collision.gameObject.GetComponent<Asteroid>().Die();
            Die();*/
        }
    }
}
