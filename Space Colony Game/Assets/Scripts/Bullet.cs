using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed / 1000f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Asteroid"))
        {
            //scatter asteroids
            collision.gameObject.GetComponent<Asteroid>().Die();
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            collision.gameObject.GetComponent<Enemy>().Die();
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
