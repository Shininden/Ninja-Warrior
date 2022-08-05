using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    float attackRate = 2f;
    float nextAttackTime;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed && Time.time >= nextAttackTime)
        {
            anim.SetTrigger("Attacking");
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
}