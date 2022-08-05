using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurMovement : StateMachineBehaviour
{
    [SerializeField] float spd;
    [SerializeField] float attackRange;
    [SerializeField] float distanceToWalk = 18f;

    Transform player;
    Rigidbody2D rb;
    FacePlayer minotaur;

    override public void OnStateEnter(Animator anim, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = anim.GetComponent<Rigidbody2D>();
        minotaur = anim.GetComponent<FacePlayer>();
    }

    override public void OnStateUpdate(Animator anim, AnimatorStateInfo stateInfo, int layerIndex)
    {
        minotaur.FaceTarget();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, spd * Time.fixedDeltaTime);
        
        //if the distance between the minotaur and the variable be less or equal, it will move
        if (Vector2.Distance(player.position, rb.position) <= distanceToWalk)
            rb.MovePosition(newPos);

        //if the distance between the minotaur and the variable be less or equal, it will attack
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
            anim.SetTrigger("Attack");
    }


    override public void OnStateExit(Animator anim, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anim.ResetTrigger("Attack");
    }
}
