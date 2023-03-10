using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Power { TrippleShot, EnergyShield, PotatoBomb}
    public Power power;

    Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Destroy(gameObject, 60f);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            switch(power)
            {
                case Power.TrippleShot:
                    player.TripleShotsActive();
                    player.ResetTripleShots();
                    break;

                case Power.EnergyShield:
                    player.EnergyShieldActive();
                    break;

                case Power.PotatoBomb:
                    player.PotatoBomb();
                    break;
            }

            FindObjectOfType<AudioManager>().Play("PowerUp");
            Destroy(gameObject);
        }
    }
}
