using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArea : MonoBehaviour
{
    public GameObject erf;
    public GameObject Mar;
    private float posX;
    public float maxXPos;
    public float minXPos;
    private float posY;
    public float maxYPos;
    public float minYPos;
    private float PlanetAmount;
    private bool overlap;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnErf();
        SpawnMar();

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

    public void SpawnErf()
    {

        PlanetAmount = Random.Range(1,4);
        for (int i = 0; i < PlanetAmount; i++)
        {
            Instantiate(erf, new Vector3(GetXPos(posX), GetYPos(posY), 0), Quaternion.identity);
            
        }
    }

    public void SpawnMar()
    {

        PlanetAmount = Random.Range(1,4);
        for (int i = 0; i < PlanetAmount; i++)
        {
            Instantiate(Mar, new Vector3(GetXPos(posX), GetYPos(posY), 0), Quaternion.identity);

        }
    }


}
