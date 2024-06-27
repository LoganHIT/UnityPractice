using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //X axis value
    private float horizontal;
    //movement speed
    private float speed = 8f;
    //speed at which you will jump
    private float jumpingPower = 16f;
    //check if facing right
    private bool isFacingRight = true;
    private bool doubleJumped = false;

    //Grabs outside input from unity
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        //Takes in the Horizontal X axis value
        //returns value between -1 and 1 depending on which direction you are moving
        horizontal = Input.GetAxisRaw("Horizontal");

        //If the jump button is pressed
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            doubleJumped = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        //If jump is pressed and player not on ground, resulting in double jump
        if (Input.GetButtonDown("Jump") && !IsGrounded() && doubleJumped == false)
        {
            doubleJumped = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        //If jump button is released
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }
    private void FixedUpdate()
    {
        //
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool IsGrounded()
    {
        //Checks if the character is on the ground somehow
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        //If we are FacingRight = true, && horizontal is < 0f OR FacingRight = false, && horizontal is > 0f
        if ((isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f))
        {
            //Invert the true or false
            isFacingRight = !isFacingRight;
            //
            Vector3 localScale = transform.localScale;
            //
            localScale.x *= -1f;
            //
            transform.localScale = localScale;
        }
    }
}
