using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddColony : MonoBehaviour
{
    public GameObject Colony;
    public bool IsColonised;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsColonised)
        {
            Colony.SetActive(true);
        }
    }
}
