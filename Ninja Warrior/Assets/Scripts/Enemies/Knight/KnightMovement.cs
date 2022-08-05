using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    [SerializeField] Transform leftEdge, rightEdge;
    [SerializeField] float spd;

    Animator anim;
    KnightAttack kA;
    public GameObject triggerArea;
    [HideInInspector] public Transform target;

    void Awake()
    {
        SelectTarget();
        anim = GetComponent<Animator>();
        kA = GetComponent<KnightAttack>();
    }

    void Update()
    {
        if (!kA.attackMode)
            MoveToTarget();

        if (!InsideOfLimits() && !kA.playerInRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            SelectTarget();

        Flip();
    }

    void MoveToTarget()
    {
        anim.SetBool("Walking", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Vector2 targetPos = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPos, spd * Time.deltaTime);
        }
    }

    public void SelectTarget()
    {
        float distanceToLeftEdge = Vector2.Distance(transform.position, leftEdge.position);
        float distanceToRightEdge = Vector2.Distance(transform.position, rightEdge.position);

        if (distanceToLeftEdge > distanceToRightEdge)
            target = leftEdge;
        else
            target = rightEdge;

        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;

        if (transform.position.x > target.position.x)
            rotation.y = 180f;
        else
            rotation.y = 0f;
        transform.eulerAngles = rotation;
    }

    bool InsideOfLimits()
    {
        return transform.position.x > leftEdge.position.x && transform.position.x < rightEdge.position.x;
    }
}