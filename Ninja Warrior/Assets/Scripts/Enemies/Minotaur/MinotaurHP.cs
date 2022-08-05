using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurHP : MonoBehaviour
{
    [SerializeField] GameObject deathAnim;
    [SerializeField] int scorePoints;
    public static int hp = 100;
    float dmgTime = 1;

    public void TookDamage(int dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            //the HUD will receive the points
            Score.points = scorePoints;
            Instantiate(deathAnim, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
            StartCoroutine(Damage());

        if (hp <= 25)
            GetComponent<Animator>().SetBool("isEnraged", true);
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