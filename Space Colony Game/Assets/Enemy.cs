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

    private float pSpeed, attackTimer;
    Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
            Instantiate(bullet);
            attackTimer = attackCooldown;
        }
    }

    void RotateToPlayer()
    {
        Vector2 direction = player.transform.position - transform.position;
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation - 90f);
    }
}
