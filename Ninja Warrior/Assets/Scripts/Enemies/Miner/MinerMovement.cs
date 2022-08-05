using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerMovement : MonoBehaviour
{
    [SerializeField] float distanceToWalk;
    bool mustWalk;

    Animator anim;
    Transform target;
    Rigidbody2D rb;
    MinerAttack mA;

    bool isFacingR = true;
    float targetDistance;
    float spd = 3;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        mA = GetComponent<MinerAttack>();
    }

    void Update()
    {
        targetDistance = transform.position.x - target.position.x;

        anim.SetBool("Walk", mustWalk);

        if (Mathf.Abs(targetDistance) < distanceToWalk)
            mustWalk = true;

        if (Mathf.Abs(targetDistance) < mA.attackRange)
        {
            mA.mustAttack = true;
            mustWalk = false;
        }
    }

    private void FixedUpdate()
    {
        if (mustWalk && !mA.mustAttack)
            MoveToTarget();
    }

    void MoveToTarget()
    {
        if (targetDistance < 0)
        {
            rb.velocity = new Vector2(spd, rb.velocity.y);
            if (!isFacingR)
                Flip();
        }
        else
        {
            rb.velocity = new Vector2(-spd, rb.velocity.y);
            if (isFacingR)
                Flip();
        }
    }

    void Flip()
    {
        isFacingR = !isFacingR;

        transform.Rotate(0f, 180f, 0f);
    }
}
