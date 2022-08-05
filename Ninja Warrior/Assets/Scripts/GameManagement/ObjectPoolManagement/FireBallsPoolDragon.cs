using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallsPoolDragon : MonoBehaviour
{
    [SerializeField] GameObject fireBallsDragon;
    int amountToPool = 5;

    List<GameObject> instances;
    int lastInstanceIndex = 0;
    void Awake()
    {
        instances = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(fireBallsDragon);
            obj.SetActive(false);
            instances.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        GameObject instance = instances[lastInstanceIndex++];
        if (lastInstanceIndex >= instances.Count)
            lastInstanceIndex = 0;
        
        return instance;
    }
}