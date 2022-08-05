using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    #region Status Parameters
    //It's been check in GameController
    public static int hp = 50;
    [SerializeField] GameObject deathAnim;
                     float dmgTime = 1;
    #endregion

    #region ShootParameters
    [SerializeField] Transform shotSpawner;
    [SerializeField] GameObject fireball;
    [SerializeField] FireBallsPoolDragon fireBallsPool;
    [SerializeField] float attackCooldown;
    [SerializeField] float shootRange;                    
    [SerializeField] float fireRate;
                     float nextFire;
                     float cooldownTimer = Mathf.Infinity;
    #endregion

    #region ColliderParameters
    [SerializeField] float colliderDistance;
    [SerializeField] BoxCollider2D boxCollider;
    #endregion

    [SerializeField]  LayerMask playerLayer;

    #region private variables
    Patrol enemyPatrol;
    Transform target;
    Animator anim;
    float targetDistance;
    bool isFacingR = true;
    #endregion

    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<Patrol>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        targetDistance = transform.position.x - target.position.x;

        cooldownTimer += Time.deltaTime;

        if (CanShoot())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("Shooting");
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !CanShoot();

        if (Time.time > nextFire)
            nextFire = Time.time + fireRate;

        FacePlayer();
    }

    void FacePlayer()
    {
        if (targetDistance < 0)
        {
            if (isFacingR)
                Flip();
        }
        else
        {
            if (!isFacingR)
                Flip();
        }
    }

    bool CanShoot()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * shootRange * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * shootRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    public void Shoot()
    {
        cooldownTimer = 0;

        GameObject fireBall = fireBallsPool.GetPooledObject();
        fireBall.transform.position = shotSpawner.position;
        fireBall.transform.rotation = shotSpawner.rotation;
        fireBall.SetActive(true);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * shootRange * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * shootRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    void Flip()
    {
        isFacingR = !isFacingR;

        transform.Rotate(0f, 180f, 0f);
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
        for (float i = 0; i < dmgTime; i += 0.2f)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }
}