using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;

    private float walkSpeed = 15f;
    private float sprintSpeed = 23f;
    private float moveSpeed;

    //gravity variables
    public float grav = -9.81f;
    Vector3 velocity;
    private bool isGrounded;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    // Update is called once per frame
    void Update()
    {
        KeyboardMovement();
    }

    void KeyboardMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * walkSpeed * Time.deltaTime);

        //gravity pull
        velocity.y += grav * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f + grav);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
    }
}
