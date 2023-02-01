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
    public ParticleSystem explosion;
    public ParticleSystem cannonVFX;
    public GameObject engineAnimation;

    [Header("UI")]
    public TextMeshProUGUI healthText;

    [Header("Private Variables")]
    private float vertical, horizontal;
    private float shootTimer, flashTimer;
    private float velocity;
    private float startingCamSize;
    private bool spriteBool = false;
    private Rigidbody2D rb;
    private CapsuleCollider2D collider;
    private AudioManager audioManager;
    private SpriteRenderer renderer;

    [HideInInspector]
    public int currentHealth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        currentHealth = startingHealth;
        shootTimer = shootingCooldown;
        flashTimer = 0.125f;
        startingCamSize = Camera.main.orthographicSize;

        if (currentHealth > 0)
        {
            audioManager.Play("Jet Engine");
        }
    }

    void Update()
    {
        engineAnimation.gameObject.SetActive(vertical == 1);

        Rotate();
        Shoot();
        Die();
        UIElements();
        ShootingTimer();
        VelocityControl();
        InvulnerablePerks();
        CameraSizeChange();
        SFX();
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
            audioManager.Play("Player Damaged");
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
            Instantiate(explosion.gameObject, transform.position - Vector3.one, explosion.transform.rotation);
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
        {
          //  collider.enabled = false;
            FlashingSprite();
        }
        else
        {
           // collider.enabled = true;
            renderer.enabled = true;
        }
    }

    void FlashingSprite()
    {
        flashTimer -= Time.deltaTime;

        if (flashTimer <= 0f)
        {
            spriteBool = !spriteBool;
            flashTimer = 0.125f;
        }

        renderer.enabled = spriteBool;
        engineAnimation.gameObject.GetComponent<SpriteRenderer>().enabled = spriteBool;
    }

    void CameraSizeChange()
    {
        Camera.main.orthographicSize = startingCamSize + rb.velocity.magnitude;

        if(Camera.main.orthographicSize >= 13f)
        {
            Camera.main.orthographicSize = 13f;
        }
    }

    void SFX()
    {
        if(currentHealth <= 0)
        {
            audioManager.sounds[5].source.Stop();
        }

        if(horizontal != 0 && !audioManager.sounds[6].source.isPlaying)
        {
            audioManager.Play("Rotating Ship");
        }
    }
}
