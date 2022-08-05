using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
    KnightAttack kA;
    KnightMovement kM;
    Animator anim;
    bool playerInRage;

    void Awake()
    {
        kA = GetComponentInParent<KnightAttack>();
        kM = GetComponentInParent<KnightMovement>();
        anim = GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (playerInRage && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            kM.Flip();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            playerInRage = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        playerInRage = false;
        
        gameObject.SetActive(false);
        
        kM.triggerArea.SetActive(true);      
        kA.playerInRange = false;     
        kM.SelectTarget();
    }
}