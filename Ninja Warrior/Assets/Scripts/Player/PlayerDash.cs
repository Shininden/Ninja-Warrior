using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerDash : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    
    PlayerMovement pM;
    PlayerStatus pS;
    [SerializeField] float dashTime, dashSpd, distanceBetweenImgs;
    
    float dashTimeLeft, lastImgXPos;
    bool isDashing;

    //It's been checked in GameController
    public static bool hasDashPower;

    [SerializeField] float manaCost;
    void Awake()
    {
        pM = GetComponent<PlayerMovement>();
        pS = GetComponent<PlayerStatus>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        CheckDash();
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && hasDashPower && pS.mana >= manaCost)
        {
            isDashing = true;
            anim.SetTrigger("Striking");
            dashTimeLeft = dashTime;

            AfterImagePool.instance.GetFromPool();
            lastImgXPos = transform.position.x;
        }
    }
    public void CheckDash()
    {
        if (isDashing)
        {
            DoDash();

            if (dashTimeLeft <= 0)
                isDashing = false;
                
            pS.mana -= manaCost;
            pS.UpdateManaUI();
        }
    }

    void DoDash()
    {
        if (dashTimeLeft > 0)
        {
            if (pM.isFacingRight)
                rb.velocity = new Vector2(dashSpd, 0);
            else
                rb.velocity = new Vector2(-dashSpd, 0);

            dashTimeLeft -= Time.deltaTime;

            if (Mathf.Abs(transform.position.x - lastImgXPos) > distanceBetweenImgs)
            {
                AfterImagePool.instance.GetFromPool();
                lastImgXPos = transform.position.x;
            }
        }
    }
}