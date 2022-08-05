using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    //It's been changed in all enemies
    public static int points;

    Text score;
    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = "Score " + points;
    }
}