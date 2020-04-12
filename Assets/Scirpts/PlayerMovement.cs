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
        //Move
        if (player == 1)
        {
            horizontalMove = Input.GetAxisRaw("PlayerOneHorizontal") * runSpeed;
            verticalMove = Input.GetAxisRaw("PlayerOneVertical");

            int charactor = CharactorSelectionModel.playerOne;
            if (charactor == 0 || charactor == 1)
            {
                LiuBeiCaoCaoRun();
                LiuBeiCaoCaoJump();
                LiuBeiCaoCaoCrouch();
            } else if (charactor == 2)
            {
                SunQuanRun();
                SunQuanJump();
                SunQuanCrouch();
            }

        } else if (player == 2)
        {
            horizontalMove = Input.GetAxisRaw("PlayerTwoHorizontal") * runSpeed;
            verticalMove = Input.GetAxisRaw("PlayerTwoVertical");

            int charactor = CharactorSelectionModel.playerTwo;
            if (charactor == 0 || charactor == 1)
            {
                LiuBeiCaoCaoRun();
                LiuBeiCaoCaoJump();
                LiuBeiCaoCaoCrouch();
            }
            else if (charactor == 2)
            {
                SunQuanRun();
                SunQuanJump();
                SunQuanCrouch();
            }
        }

    }

    private void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void LiuBeiCaoCaoRun()
    {
        if (Mathf.Abs(horizontalMove) > 0)
        {
            animator.SetInteger("AnimState", 2);
        }
        else
        {
            animator.SetInteger("AnimState", 0);
        }
    }

    private void LiuBeiCaoCaoJump()
    {
        if ((player == 1 && Input.GetKeyDown(KeyCode.W)) || (player == 2 && Input.GetKeyDown(KeyCode.UpArrow)))
        {
            jump = true;
        }

        if (verticalMove == 1) //jumping
        {
            animator.SetFloat("AirSpeed", -1);
        }
        else
        {
            animator.SetFloat("AirSpeed", 0);
        }
        animator.SetBool("Grounded", (verticalMove == 0));
    }

    private void LiuBeiCaoCaoCrouch()
    {
        if ((player == 1 && Input.GetKeyDown(KeyCode.S)) || (player == 2 && Input.GetKeyDown(KeyCode.DownArrow)))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void SunQuanRun()
    {

    }

    private void SunQuanJump()
    {

    }

    private void SunQuanCrouch()
    {

    }
}
