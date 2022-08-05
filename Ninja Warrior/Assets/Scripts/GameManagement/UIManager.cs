using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Slider hpBar;
    public Text hpText;
    public Text livesText;

    public Slider manaBar;

    public Text scoreText;

    public void UpdateHealthUI(int health)
    {
        hpBar.value = health;
        hpText.text = health.ToString();       
    }

    public void UpdateLivesUI(int vidas)
    {
        livesText.text = vidas.ToString("x " + vidas);
    }

    public void UpdateManaUI(float mana)
    {
        manaBar.value = mana;
    }
}