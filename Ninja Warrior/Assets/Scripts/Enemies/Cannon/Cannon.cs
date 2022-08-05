using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cannon : MonoBehaviour
{
    #region toBeSpawn
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject laser;
    [SerializeField] Transform laserSpawn;
    [SerializeField] Transform enemySpawn;
    [SerializeField] Rigidbody2D bullet;
    [SerializeField] Transform[] shotSpawners;
    #endregion

    SpriteRenderer sprite;

    #region values
    [SerializeField] float minYForce, maxYForce;
    [SerializeField] float fireRateMin, fireRateMax;
    [SerializeField] float minEnemyTime, maxEnemyTime;
    [SerializeField] float minLaserTime, maxLaserTime;
    #endregion

    public static int hp = 100;

    bool isDead = false;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ActivateBoss()
    {
        GetComponent<PolygonCollider2D>().enabled = true;
        Invoke("Fire", Random.Range(fireRateMin, fireRateMax));
        Invoke("InstantiateEnemies", Random.Range(minEnemyTime, maxEnemyTime));
        Invoke("FireLaser", Random.Range(minLaserTime, maxLaserTime));
    }

    void Fire()
    {
        if (!isDead)
        {
            Rigidbody2D tempBullet = Instantiate(bullet, shotSpawners[Random.Range(0, shotSpawners.Length)].position, Quaternion.identity);
            tempBullet.AddForce(new Vector2(0, Random.Range(minYForce, maxYForce)), ForceMode2D.Impulse);
            Invoke("Fire", Random.Range(fireRateMin, fireRateMax));
        }
    }

    void InstantiateEnemies()
    {
        if (!isDead)
        {
            Instantiate(enemy, enemySpawn.position, enemySpawn.rotation);
            Invoke("InstantiateEnemies", Random.Range(minEnemyTime, maxEnemyTime));
        }
    }

    void FireLaser()
    {
        if(!isDead)
        {
            Instantiate(laser, laserSpawn.position, laserSpawn.rotation);
            Invoke("FireLaser", Random.Range(minLaserTime, maxLaserTime));
        }
    }

    public void TookDamage(int dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            Score.points += 30;
            isDead = true;
            sprite.color = Color.black;
        }
        else
            StartCoroutine(TookDamageCoroutine());
    }

    IEnumerator TookDamageCoroutine()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}