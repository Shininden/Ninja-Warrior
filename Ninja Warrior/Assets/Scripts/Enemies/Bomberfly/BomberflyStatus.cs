using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberflyStatus : MonoBehaviour
{
    [SerializeField] GameObject deathAnim;
    [SerializeField] int scorePoints;
    [SerializeField] int hp = 5;
    float dmgTime = 1;
    
    public void TookDamage(int dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            Score.points = scorePoints;
            Instantiate(deathAnim, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
            StartCoroutine(Damage());
    }

    IEnumerator Damage()
    {
        for (float i = 0; i < dmgTime; i += 0.2f)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }
}