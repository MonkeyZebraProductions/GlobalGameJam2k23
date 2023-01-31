using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapScript : MonoBehaviour
{
    private Transform ship;
    private Rigidbody2D shipRB;
    private RandomArea rA;

    // Start is called before the first frame update
    void Start()
    {
        rA = FindObjectOfType<RandomArea>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ship = collision.gameObject.transform;
        shipRB = collision.gameObject.GetComponent<Rigidbody2D>();

        if (shipRB.velocity.x < 0.1f)
        {
            float xPos = ship.position.x;
            xPos *= -1;
            ship.position = new Vector2(xPos,ship.position.y);
        }

        if (shipRB.velocity.x > 0.1f)
        {
            float xPos = ship.position.x;
            xPos *= -1;
            ship.position = new Vector2(xPos, ship.position.y);
        }

        //rA.SpawnPlanet();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
