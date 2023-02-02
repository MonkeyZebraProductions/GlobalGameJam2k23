using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDangerous : MonoBehaviour
{
    public Player player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            if (player.velocity > 2f)
            {
                player.Die();   
            }
        }
        
    }
}
