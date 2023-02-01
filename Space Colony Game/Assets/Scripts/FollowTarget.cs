using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float z = 0;

    void Update()
    {
        Vector3 pos = new Vector3(target.position.x, target.position.y, z);
        transform.position = pos;
    }
}
