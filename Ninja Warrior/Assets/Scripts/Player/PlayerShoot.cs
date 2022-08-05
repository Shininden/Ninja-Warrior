using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerShoot : MonoBehaviour
{
    Animator anim;
    PlayerMovement pM;
    PlayerStatus pS;

    float fireRate = 0.5f, nextFire;

    [SerializeField] Transform shotSpawner;
    [SerializeField] GameObject fireBallPrefab;
    [SerializeField] FireBallsPoolPlayer fireBallsPool;
    [SerializeField] int manaCost;

    //it's been acessed in the GameController script
    public static bool hasFirePower;
    void Start()
    {
        anim = GetComponent<Animator>();
        pM = GetComponent<PlayerMovement>();
        pS = GetComponent<PlayerStatus>();
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed && hasFirePower && pS.mana >= manaCost && Time.time > nextFire && pM.canFire())
        {
            nextFire = Time.time + fireRate;
            anim.SetTrigger("Firing");
            Invoke("Shoot", 0.4f);
        }
    }

    void Shoot()
    {
        GameObject fireBall = fireBallsPool.GetPooledObject();
        fireBall.transform.position = shotSpawner.position;
        fireBall.transform.rotation = shotSpawner.rotation;
        fireBall.SetActive(true);

        pS.mana -= manaCost;
        pS.UpdateManaUI();
    }
}