using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttack : MonoBehaviour
{
    [HideInInspector] public bool playerInRange;
    [HideInInspector] public bool attackMode;
    public float attackRange;
    float targetDistance;

    public GameObject hotZone;
    KnightMovement kM;
    Animator anim;

    void Awake()
    {
        kM = GetComponent<KnightMovement>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerInRange)
            AttackLogic();
    }

    void AttackLogic()
    {
        targetDistance = Vector2.Distance(transform.position, kM.target.position);

        if (targetDistance > attackRange)
            StopAttack();

        else if (attackRange >= targetDistance)
            Attack();
    }

    void Attack()
    {
        attackMode = true;
        anim.SetBool("Walking", false);
        anim.SetBool("Attacking", true);
    }

    void StopAttack()
    {
        attackMode = false;
        anim.SetBool("Attacking", false);
    }
}