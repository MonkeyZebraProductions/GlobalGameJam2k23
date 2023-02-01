using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour
{
    public Rigidbody2D ShipRB;
    private AddColony aC;
    private bool slow;
    private void Update()
    {
        if(ShipRB.velocity.magnitude < 1f)
        {
            slow = true;
        }
        else
        {
            slow = false;
        }
        Debug.Log(slow);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(slow)
        {
            aC = collision.gameObject.GetComponent<AddColony>();
            aC.IsColonised = true;
        }
    }
}
