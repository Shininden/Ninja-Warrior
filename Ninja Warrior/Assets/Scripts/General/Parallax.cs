using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Vector3 previousPos;
    [SerializeField] Transform target;
    [SerializeField] float paralxspd;

    void Start()
    {
        previousPos = target.position;
    }

    void Update()
    {
        Vector3 deltaMovement = target.position - previousPos;
        transform.position += deltaMovement * paralxspd;
        previousPos = target.position;
    }
}