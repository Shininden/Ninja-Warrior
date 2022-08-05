using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberflyMovement : MonoBehaviour
{
    [SerializeField] Transform[] points;
    Transform target;
    float targetDistance;

    int startingPoint;
    int i;
    float spd = 2;
    bool isFacingR = true;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        //the transform receives the points inside the array
        transform.position = points[startingPoint].position;
    }

    void Update()
    {
        targetDistance = transform.position.x - target.position.x;

        if (targetDistance < 0)
        {
            if (!isFacingR)
                Flip();
        }
        else
        {
            if (isFacingR)
                Flip();
        }

        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            
            if (i == points.Length)
                i = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, spd * Time.deltaTime);
    }

    void Flip()
    {
        isFacingR = !isFacingR;

        transform.Rotate(0f, 180f, 0f);
    }
}