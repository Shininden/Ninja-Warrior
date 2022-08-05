using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] Transform leftEdge;
    [SerializeField] Transform rightEdge;

    [SerializeField] Transform enemy;
    [SerializeField] float spd;

    [SerializeField] Animator anim;

    Vector3 initScale;
    bool isMovingLeft;

    void Awake()
    {
        initScale = enemy.localScale;
    }

    void OnDisable()
    {
        anim.SetBool("isWalking", false);
    }

    void Update()
    {
        if(isMovingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                Move(-1);
            else
                ChangeDirection();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                Move(1);
            else
                ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        anim.SetBool("isWalking", false);
        isMovingLeft = !isMovingLeft;
    }
        

    void Move(int direction)
    {
        anim.SetBool("isWalking", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * spd, enemy.position.y, enemy.position.z);
    }
}