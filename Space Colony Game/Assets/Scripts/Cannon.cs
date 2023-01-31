using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float radius = 1f;

    Transform pivot;

    void Start()
    {
        pivot = player;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;
    }

    void Update()
    {
        Orbit();
    }

    void Orbit()
    {
        Vector3 vector = Camera.main.WorldToScreenPoint(player.position);
        vector = Input.mousePosition - vector;
        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

        pivot.position = player.position;
        pivot.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }

    void OldOrbit()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

        Vector3 gunPosition = Vector3.ClampMagnitude(direction, 1f);

        if (Vector3.Distance(transform.position, player.position) <= 1f)
        {
            gunPosition = Vector3.ClampMagnitude(direction, 1f);
        }

        transform.position = player.position + gunPosition;
    }
}
