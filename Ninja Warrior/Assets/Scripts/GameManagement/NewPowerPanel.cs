using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewPowerPanel : MonoBehaviour
{
    [SerializeField] GameObject powerPanel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            powerPanel.SetActive(true);
            
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            powerPanel.SetActive(false);
            
    }
}