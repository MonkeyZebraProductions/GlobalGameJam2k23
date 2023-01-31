using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArea : MonoBehaviour
{
    public GameObject DeadPlanet;
    public GameObject Planet;
    public GameObject Sun;
    private float posX;
    public float maxXPos;
    public float minXPos;
    private float posY;
    public float maxYPos;
    public float minYPos;
    private float PlanetAmount;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlanet();

    }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    float GetXPos(float xPos)
    {
        xPos = Random.Range(minXPos, maxXPos);

       // while (xPos >= -10 && xPos <= 10)
       // {
        //    xPos = Random.Range(minXPos, maxXPos);
        //}

        return xPos;
    }

    float GetYPos(float yPos)
    {
        yPos = Random.Range(minXPos, maxXPos);

       // while (yPos >= -10 && yPos <= 10)
       // {
        //    yPos = Random.Range(minXPos, maxXPos);
        //}

        return yPos;
    }

    public void SpawnPlanet()
    {
        float SunRadius = Sun.GetComponent<Collider2D>().bounds.extents.x;
        float PlanetRadius = Planet.GetComponent<Collider2D>().bounds.extents.x;

        PlanetAmount = Random.Range(2, 6);
        for (int i = 0; i < PlanetAmount; i++)
        {
            Vector2 spawnPoint = new Vector2(GetXPos(posX), GetYPos(posY));
            Collider2D CollisionWIthSun = Physics2D.OverlapCircle(spawnPoint, SunRadius, LayerMask.GetMask("Overlap"));
            Collider2D CollisionWIthPlanet = Physics2D.OverlapCircle(spawnPoint, PlanetRadius, LayerMask.GetMask("Overlap"));

            if (CollisionWIthPlanet == false && CollisionWIthSun == false)
            {
                Instantiate(Planet, new Vector3(GetXPos(posX), GetYPos(posY), 0), Quaternion.identity);
            }
        }
    }
}
