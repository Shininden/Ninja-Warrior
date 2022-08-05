using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLaser : MonoBehaviour
{
    [SerializeField] int dmg;
    [SerializeField] float destroyTime;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStatus otherPlayer = other.GetComponent<PlayerStatus>();

        if (otherPlayer != null)
            otherPlayer.TookDamage(dmg);
    }
}