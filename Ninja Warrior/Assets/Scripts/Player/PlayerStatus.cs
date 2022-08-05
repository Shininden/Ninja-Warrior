using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStatus : MonoBehaviour
{
    int hp;
    [SerializeField] int maxHp;
    //It's been used in HUDController
    public static int lives = 3;
     
    Vector3 respawnPoint;
    SpriteRenderer sprite;
    Animator anim;
    //It's been used by PlayerDash and Shoot
    public float mana;
    [SerializeField] float maxMana, manaRegen;

    bool tookDmg = false;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        hp = maxHp;
        UpdateHPUI();

        mana = maxMana;
        UpdateManaUI();

        respawnPoint = transform.position;
    }

    void Update()
    {
        RefillMana();
    }

    void UpdateHPUI()
    {
        FindObjectOfType<UIManager>().UpdateHealthUI(hp);
    }
    void UpdateLivesUI()
    {
        FindObjectOfType<UIManager>().UpdateLivesUI(lives);
    }

    public void UpdateManaUI()
    {
        FindObjectOfType<UIManager>().UpdateManaUI(mana);
    }

    void RefillMana()
    {
        if (mana < maxMana)
        {
            mana = Mathf.MoveTowards(mana / maxMana, maxMana, Time.deltaTime * manaRegen) * maxMana;
            UpdateManaUI();
        }

        else if (mana > maxMana)
            mana = maxMana;

        if (mana < 0)
            mana = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
            respawnPoint = other.transform.position;
    }

    public void TookDamage(int dmg)
    {
        tookDmg = true;
        hp -= dmg;
        UpdateHPUI();

        if (hp <= 0)
        {
            Invoke("Respawn", 0.1f);
            lives--;
            UpdateLivesUI();
        }

        if (tookDmg)
            StartCoroutine(Damaged());
    }

    IEnumerator Damaged()
    {
        anim.SetTrigger("Hurt");
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

    void Respawn()
    {
        hp = maxHp;
        UpdateHPUI();
        transform.position = respawnPoint;
    }

    public void Heal(int life, int vidas)
    {
        hp += life;

        if (hp >= maxHp)
            hp = maxHp;

        UpdateHPUI();

        lives += vidas;

        UpdateLivesUI();
    }
}
