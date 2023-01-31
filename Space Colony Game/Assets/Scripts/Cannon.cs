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
}
