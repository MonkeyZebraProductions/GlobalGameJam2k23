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
    public float velocityLimit;
    public float velocity;

    [Header("Cannon")]
    public GameObject cannonObject;
    public GameObject bulletPrefab;
    public float rotationSpeed;
    public KeyCode shootingKey = KeyCode.Mouse0;

    [Header("UI")]
    public TextMeshProUGUI healthText;

    [Header("Private Variables")]
    private float vertical, horizontal;
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

    }

    void Update()
    {
        Movement();
        //MoveCannon();
        Shoot();
        Die();
        UIElements();
        VelocityControl();
    }

    void Movement()
    {
        Vector2 movement = new Vector2(horizontal, vertical);
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        rb.AddForce(movement * speed);
    }

    void MoveCannon()
    {
        Vector3 mouseVector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        Vector2 direction = (Camera.main.ScreenToWorldPoint(mouseVector) - cannonObject. transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.localPosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        cannonObject.transform.rotation = Quaternion.Slerp(cannonObject.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        //cannonObject.transform.rotation = Quaternion.Lerp(cannonObject.transform.rotation, rotation, rotationSpeed);
        //cannonObject.transform.rotation = rotation;


    }

    void Shoot()
    {
        if(Input.GetKeyDown(shootingKey))
        {
            Instantiate(bulletPrefab, cannonObject.transform.position, cannonObject.transform.rotation);
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

    void VelocityControl()
    {
        velocity = rb.velocity.magnitude;

        if (velocity >= velocityLimit)
        {
            velocity = velocityLimit;
        }
    }
}
