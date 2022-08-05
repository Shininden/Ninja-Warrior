using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    Transform player;
    SpriteRenderer playerSprite;

    SpriteRenderer sprite;
    Color color;

    float activeTime = 0.1f, timeActivated;
    float alpha, alphaSet = 0.8f, alphaMultiplier = 0.90f;

    void OnEnable()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSprite = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        sprite.sprite = playerSprite.sprite;

        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        transform.position = player.position;
        transform.rotation = player.rotation;

        timeActivated = Time.time;
    }

    void Update()
    {
        alpha *= alphaMultiplier;
        color = new Color(1f, 1f, 1f, alpha);
        sprite.color = color;

        if(Time.time >= (timeActivated + activeTime))
            AfterImagePool.instance.AddToPool(gameObject);
    }
}