using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightStatus : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] GameObject deathAnim;

    SpriteRenderer sprite;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void TookDamage(int dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            Score.points += 10;
            Instantiate(deathAnim, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
            StartCoroutine(Damage());
    }

    IEnumerator Damage()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}