using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    Transform target;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void FaceTarget()
    {
        Vector3 rotation = transform.eulerAngles;

        if (target.position.x < transform.position.x)
            rotation.y = 180f;    

        else if(transform.position.x < target.position.x)
            rotation.y = 0f;   

        transform.eulerAngles = rotation;
    }
}