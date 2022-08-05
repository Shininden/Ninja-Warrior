using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float spd;
    [SerializeField] int dmg;
    [SerializeField] float deactivateTime;
    Rigidbody2D rb;

    private void OnEnable()
    {
        StartCoroutine(DisableProjectile());
    }

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator DisableProjectile()
    {
        yield return new WaitForSeconds(deactivateTime);
        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.right * spd;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        KnightStatus knight = other.GetComponent<KnightStatus>();
        BomberflyStatus bomberfly = other.GetComponent<BomberflyStatus>();
        MinerStatus miner = other.GetComponent<MinerStatus>();
        Dragon dragon = other.GetComponent<Dragon>();
        Cannon cannon = other.GetComponent<Cannon>();
        MinotaurHP minotaur = other.GetComponent<MinotaurHP>();

        PlayerStatus player = other.GetComponent<PlayerStatus>();

        if (knight != null)
        {
            knight.TookDamage(dmg);
            gameObject.SetActive(false);
        }

        if (bomberfly != null)
        {
            bomberfly.TookDamage(dmg);
            gameObject.SetActive(false);
        }

        if (miner != null)
        {
            miner.TookDamage(dmg);
            gameObject.SetActive(false); ;
        }

        if (dragon != null)
        {
            dragon.TookDamage(dmg);
            gameObject.SetActive(false);
        }

        if (cannon != null)
        {
            cannon.TookDamage(dmg);
            gameObject.SetActive(false);
        }

        if(minotaur != null)
        {
            minotaur.TookDamage(dmg);
            gameObject.SetActive(false);
        }


        if (player != null)
        {
            player.TookDamage(dmg);
            gameObject.SetActive(false);
        }
    }
}