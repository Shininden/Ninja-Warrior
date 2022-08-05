using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberflyShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shotSpawner;
    [SerializeField] BulletBomberflyPool bulletPool;

    public void Shooting()
    {
        GameObject bullet = bulletPool.GetPooledObject();
        bullet.transform.position = shotSpawner.position;
        bullet.transform.rotation = shotSpawner.rotation;
        bullet.SetActive(true);
    }
}
