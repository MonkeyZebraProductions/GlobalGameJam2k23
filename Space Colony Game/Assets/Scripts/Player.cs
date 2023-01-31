using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Health")]
    public int startingHealth;
    private bool canTakeDamage = true;

    [Header("Movement")]
    public float speed;
    public float rotationSpeed;
    public float velocityLimit;
    public float velocity;

    [Header("Cannon")]
    public GameObject cannonObject;
    public GameObject bulletPrefab;
    public float shootingCooldown = 0.15f;
    public KeyCode shootingKey = KeyCode.Mouse0;

    [Header("UI")]
    public TextMeshProUGUI healthText;

    [Header("Private Variables")]
    private float vertical, horizontal;
    private float shootTimer;
    private Rigidbody2D rb;

    [HideInInspector]
    public int currentHealth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentHealth = startingHealth;
        shootTimer = shootingCooldown;
    }

    void Update()
    {
        //Movement();
        Rotate();
        Shoot();
        Die();
        UIElements();
        ShootingTimer();
        VelocityControl();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        if (vertical == 1)
        {
            speed += Time.deltaTime * 2f;
        }

        else if (vertical == -1)
        {
            speed -= Time.deltaTime * 4f;
        }

        rb.AddForce(transform.up * speed);

    }

    void Rotate()
    {
        transform.Rotate(0f, 0f, -horizontal * rotationSpeed);
    }

    void Shoot()
    {
        if(Input.GetKeyDown(shootingKey) && shootTimer <= 0f)
        {
            Instantiate(bulletPrefab, cannonObject.transform.position, cannonObject.transform.rotation);
            shootTimer = shootingCooldown;
        }
    }

    public void TakeDamage(int damage)
    {
        if(canTakeDamage)
        {
            currentHealth -= damage;
            StartCoroutine(InvulnerableFrames());
        }

        else
        {
            return;
        }
    }

    void Die()
    {
        if(currentHealth <= 0)
        {
            //game over
            Destroy(gameObject);
        }
    }

    IEnumerator InvulnerableFrames()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(3f);
        canTakeDamage = true;
    }

    void UIElements()
    {
        healthText.text = currentHealth.ToString();
    }

    void ShootingTimer()
    {
        shootTimer -= Time.deltaTime;

        if(shootTimer <= 0f)
        {
            shootTimer = 0f;
        }
    }

    void VelocityControl()
    {
        velocity = rb.velocity.magnitude * speed;

        if (velocity >= velocityLimit + 0.1f)
        {
            velocity = velocityLimit;
            speed = velocityLimit;
        }

        if(speed <= -0.1f)
        {
            speed = 0f;
        }
    }
}
