 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImagePool : MonoBehaviour
{
    [SerializeField] GameObject afterImagePrefab;

    Queue<GameObject> availableObjects = new Queue<GameObject>();

    //It's been checked in PlayerDash
    public static AfterImagePool instance { get; private set; }

    void Awake() 
    {
        instance = this;
        CreateObjectsToPool();
    }

    void CreateObjectsToPool()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject instanceToAdd = Instantiate(afterImagePrefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }

    public GameObject GetFromPool()
    {
        if(availableObjects.Count == 0)
            CreateObjectsToPool();

        GameObject instance = availableObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }
}