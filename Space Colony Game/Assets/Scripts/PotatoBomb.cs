using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoBomb : MonoBehaviour
{
    public float speed, deathDelay;

    void Start()
    {
        Destroy(gameObject, deathDelay);
    }

    void Update()
    {
        transform.localScale = new Vector2(transform.localScale.x + speed * Time.deltaTime, transform.localScale.y + speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().Die();
        }

        else if(collision.CompareTag("Asteroid"))
        {
            collision.GetComponent<Asteroid>().Die();
        }
    }
}
