using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public float speed;

    [Header("Attacking")]
    public float attackRange;
    public float attackCooldown;
    public GameObject bullet;

    [Header("VFX")]
    public ParticleSystem explosion;

    private float pSpeed, attackTimer;
    AudioManager audioManager;
    Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        Movement();
        AI();
        RotateToPlayer();
    }

    void Movement()
    {
        transform.position += transform.up * pSpeed / 100f;
    }

    void AI()
    {
        if(Vector2.Distance(transform.position, player.transform.position) > attackRange)
        {
            pSpeed = speed;
            attackTimer = attackCooldown;
        }

        else if(Vector2.Distance(transform.position, player.transform.position) <= attackRange)
        {
            pSpeed = 0;
            Attack();
        }
    }

    void Attack()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f)
        {
            audioManager.Play("Enemy Shoot");
            Instantiate(bullet, transform.position + (transform.up * 0.75f), transform.rotation);
            attackTimer = attackCooldown;
        }
    }

    public void Die()
    {
        Instantiate(explosion.gameObject, transform.position, explosion.transform.rotation);
        audioManager.PlayRandomExlposion();
        Destroy(gameObject);
    }

    void RotateToPlayer()
    {
        Vector2 direction = player.transform.position - transform.position;
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation - 90f);
    }
}
