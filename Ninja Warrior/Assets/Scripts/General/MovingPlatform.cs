using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float spd;
    [SerializeField] Transform[] points;

    int startingPoint;
    int i;

    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
                i = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, spd * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.SetParent(transform);
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        other.transform.SetParent(null);
    }
}