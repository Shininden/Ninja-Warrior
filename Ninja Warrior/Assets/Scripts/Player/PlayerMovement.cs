using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    Transform groundCheck;

    [SerializeField] float spd = 5f, jumpForce = 600f;

    float inputX;
    bool isOnGround = false;
    bool isCrouched = false;
    //It's been used in PlayerDash
    public bool isFacingRight = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        groundCheck = gameObject.transform.Find("GroundCheck");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX * spd * Time.deltaTime, rb.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    void Update()
    {
        isOnGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        anim.SetBool("isJumping", isOnGround);

        if (isOnGround)
            anim.SetBool("isJumping", false);
        else
            anim.SetBool("isJumping", true);

        if (isCrouched)
            inputX = 0;

        isCrouched = Input.GetButton("Down");

        anim.SetBool("isCrouched", isCrouched);
    }

    public void Movement(InputAction.CallbackContext context)
    {        
        if (!isCrouched)
            inputX = context.ReadValue<Vector2>().x;

        if (inputX > 0 && !isFacingRight)
            Flip();

        else if (inputX < 0 && isFacingRight)
            Flip();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    public bool canFire()
    {
        return inputX == 0 && !isCrouched;
    }
}