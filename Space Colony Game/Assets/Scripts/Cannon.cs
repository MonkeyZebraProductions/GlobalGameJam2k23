using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform player;
    public float speed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

        Vector3 gunPosition = Vector3.ClampMagnitude(direction, 1f);

        if(Vector3.Distance(transform.position,player.position) <= 1f)
        {
            gunPosition = Vector3.ClampMagnitude(direction, 1f);
        }

        transform.position = player.position + gunPosition;
    }
}
