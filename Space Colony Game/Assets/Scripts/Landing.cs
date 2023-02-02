using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour
{
    public Rigidbody2D ShipRB;
    private AddColony aC;
    private bool slow;
    private ScoreManager sM;
    AudioManager audioManager;
    Player player;

    public bool CanScore;

    public float ScoreValue;

    private void Start()
    {
        sM = FindObjectOfType<ScoreManager>();
        audioManager = FindObjectOfType<AudioManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        if(ShipRB.velocity.magnitude < 2.5f)
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
        
        if(slow && CanScore)
        {
            audioManager.Play("Colonise Success");
            player.currentHealth++;
            sM.AddPoints(ScoreValue);
            aC = collision.gameObject.GetComponent<AddColony>();
            aC.IsColonised = true;
            CanScore = false;
        }
    }
}
