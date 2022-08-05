using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    [SerializeField] float newMinX;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<UnityStandardAssets._2D.CameraFollow>().minXAndY = new Vector2(newMinX, 0);
            gameObject.SetActive(false);
        }
    }
}
