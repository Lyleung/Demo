using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    public int player;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical");

        // Run
        if (Mathf.Abs(horizontalMove) > 0)
        {
            animator.SetInteger("AnimState", 2);
        } else
        {
            animator.SetInteger("AnimState", 0);
        }

        // JUMP
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (verticalMove == 1) //jumping
        {
            animator.SetFloat("AirSpeed", -1);
        } else
        {
            animator.SetFloat("AirSpeed", 0);
        }
        animator.SetBool("Grounded", (verticalMove == 0));

        //Crouch
        if (Input.GetButtonDown("Crouch")) 
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    private void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
}
