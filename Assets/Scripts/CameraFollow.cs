using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = .3f;

    // to be called after all update function
    void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            // for smoothing 
            transform.position = newPos;
        }
    }
}