using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float x = Random.Range(-55, 55);
        float y = Random.Range(-55, 55);

        if (collision.gameObject.layer == 6)
        {
            transform.position = new Vector2(x, y);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
