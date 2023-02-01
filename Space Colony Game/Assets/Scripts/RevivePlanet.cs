using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivePlanet : MonoBehaviour
{

    public Transform Player;
    public SpriteRenderer AlivePlanet;

    public bool IsColonising;
    public float AliveRate, UnaliveRate,AliveDistance,TooClose;
    private float alivePecentage;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        float playerDistance = Vector2.Distance(transform.position, Player.position);

        if(playerDistance < AliveDistance && playerDistance > TooClose)
        {
            IsColonising = true;
        }
        else
        {
            IsColonising = false;
        }


        if(IsColonising && alivePecentage<100)
        {
            alivePecentage += AliveRate * Time.deltaTime;
        }
        else if (!IsColonising && alivePecentage >=0)
        {
            alivePecentage -= UnaliveRate * Time.deltaTime;
        }

        float alpha = MapFunction(alivePecentage, 0, 100, 0, 1);

        AlivePlanet.color = new Color(AlivePlanet.color.r, AlivePlanet.color.b, AlivePlanet.color.g, alpha);

        if(alivePecentage>=100)
        {
            Destroy(this.gameObject);
        }
        Debug.Log(playerDistance);
    }

    private float MapFunction(float x, float from_min, float from_max, float to_min, float to_max)
    {
        return (x - from_min) * (to_max - to_min) / (from_max - from_min) + to_min;
    }
}
