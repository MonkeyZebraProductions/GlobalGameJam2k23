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
    public float rotationSpeed;
    public float velocityLimit;
    public float acceleration = 10f;
    public float decelaration = 10f;

    [Header("Cannon")]
    public GameObject cannonObject;
    public GameObject bulletPrefab;
    public float shootingCooldown = 0.15f;
    public KeyCode shootingKey = KeyCode.Mouse0;

    [Header("VFX")]
    public ParticleSystem cannonVFX;

    [Header("UI")]
    public TextMeshProUGUI healthText;

    [Header("Private Variables")]
    private float vertical, horizontal;
    private float shootTimer;
    private float velocity;
    private Rigidbody2D rb;
    private CircleCollider2D collider;
    private AudioManager audioManager;

    [HideInInspector]
    public int currentHealth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
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
        InvulnerablePerks();
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
            rb.AddForce(transform.up * vertical * acceleration);
        else if (vertical == -1)
            rb.AddForce(rb.velocity * vertical * decelaration);

        velocity = rb.velocity.magnitude;
    }

    void Rotate()
    {
        transform.Rotate(0f, 0f, -horizontal * rotationSpeed);
    }

    void Shoot()
    {
        if(Input.GetKeyDown(shootingKey) && shootTimer <= 0f)
        {
            audioManager.Play("Shoot");
            cannonVFX.Play();
            Instantiate(bulletPrefab, cannonObject.transform.position, cannonObject.transform.rotation);
            shootTimer = shootingCooldown;
        }
    }

    public void TakeDamage(int damage)
    {
        if(canTakeDamage)
        {
            //play damage SFX
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
            //play explosion VFX
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
        if (velocity >= velocityLimit)
        {
            velocity = velocityLimit;
        }

        if (vertical == -1 && velocity < 0.5f)
        {
            rb.velocity = Vector3.zero;
        }
    }

    void InvulnerablePerks()
    {
        if (!canTakeDamage)
            collider.enabled = false;
        else
            collider.enabled = true;
    }
}
