using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDmg : MonoBehaviour
{
    public int dmg;
    private void OnTriggerEnter2D(Collider2D other)
    {
        KnightStatus knight = other.GetComponent<KnightStatus>();
        BomberflyStatus bomberfly = other.GetComponent<BomberflyStatus>();
        MinerStatus miner = other.GetComponent<MinerStatus>();
        Dragon dragon = other.GetComponent<Dragon>();
        Cannon cannon = other.GetComponent<Cannon>();
        MinotaurHP minotaur = other.GetComponent<MinotaurHP>();
       
        PlayerStatus player = other.GetComponent<PlayerStatus>();

        if (knight != null)
            knight.TookDamage(dmg);

        if (bomberfly != null)
            bomberfly.TookDamage(dmg);

        if (miner != null)
            miner.TookDamage(dmg);

        if (dragon != null)
            dragon.TookDamage(dmg);

        if (cannon != null)
            cannon.TookDamage(dmg);

        if (minotaur != null)
            minotaur.TookDamage(dmg);
            
        if (player != null)
            player.TookDamage(dmg);
    }
}
