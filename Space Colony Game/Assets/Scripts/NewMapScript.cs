using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapScript : MonoBehaviour
{
    private Transform ship;
    private Rigidbody2D shipRB;
    private RandomArea rA;

    private bool _canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        rA = FindObjectOfType<RandomArea>();
        _canSpawn = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (collision.CompareTag("Player") && _canSpawn)
            {
                Debug.Log("ah");
                GameObject[] moons;
                moons = GameObject.FindGameObjectsWithTag("Planet");
                foreach (GameObject Planet in moons)
                {
                    Destroy(Planet);
                }
                rA.SpawnErf();
                rA.SpawnMar();
                _canSpawn = false;
                StartCoroutine(DelayRespawn());
            }

            ship = collision.gameObject.transform;
            shipRB = collision.gameObject.GetComponent<Rigidbody2D>();

        
            if (shipRB.velocity.x < -0.1f)
            {
              float xPos = ship.position.x;
                xPos *= -1;
                xPos += 1;
                ship.position = new Vector2(xPos,ship.position.y);
                
            }

            if (shipRB.velocity.x > 0.1f)
            {
                float xPos = ship.position.x;
                xPos *= -1;
                xPos += 1;
                ship.position = new Vector2(xPos, ship.position.y);
            }

            if (shipRB.velocity.y < -0.1f)
            {
                float yPos = ship.position.y;
                yPos *= -1;
                yPos -= 1;
                ship.position = new Vector2(ship.position.x, yPos);
            }

            if (shipRB.velocity.y > 0.1f)
            {
                float yPos = ship.position.y;
                yPos *= -1;
                yPos += 1;
                ship.position = new Vector2(ship.position.x, yPos);
            }
            //
           

          
        }


    }

    IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(2f);
        _canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
