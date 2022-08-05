using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerAttack : MonoBehaviour
{
    Animator anim;
    [HideInInspector] public float attackRange = 1.5f;
    [HideInInspector] public bool mustAttack = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("Attack", mustAttack);
    }

    public void ResetAttack()
    {
        mustAttack = false;
    }
}