using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour
{
    KnightMovement kM;
    KnightAttack kA;

    void Awake()
    {
        kM = GetComponentInParent<KnightMovement>();
        kA = GetComponentInParent<KnightAttack>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            
            kM.target = other.transform;         
            kA.playerInRange = true;             
            kA.hotZone.SetActive(true);
        }
    }
}