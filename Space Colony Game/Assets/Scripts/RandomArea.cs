using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArea : MonoBehaviour
{
    public GameObject Star;
    public GameObject DeadPlanet;
    public GameObject Planet;
    public GameObject Astroid;
    public GameObject Enemy;
    public GameObject Sun;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Sun, new Vector2(0, 0), Quaternion.identity);
        Instantiate(Star, new Vector2(0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
