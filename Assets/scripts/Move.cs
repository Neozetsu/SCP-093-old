using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private KeyCode up = KeyCode.W;
    private KeyCode down = KeyCode.S;
    private KeyCode left = KeyCode.A;
    private KeyCode right = KeyCode.D;
    public float speed;
    //public int heightjump;
    //public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    Animator anim;


    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            int x;
            int y;

            if (Input.GetKey(up))
                x = 1;
            else if (Input.GetKey(down))
                x = -1;
            else
                x = 0;

            if (Input.GetKey(left))
                y = -1;
            else if (Input.GetKey(right))
                y = 1;
            else
                y = 0;

            moveDirection = new Vector3(y, 0, x);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetKey(up) || Input.GetKey(down) || Input.GetKey(left) || Input.GetKey(right))
                anim.SetBool("walk", true);
            else
                anim.SetBool("walk", false);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
            
        
        /*
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
                anim.SetBool("walk", true);
            else
                anim.SetBool("walk", false);
        
            //Инновационный способ выпилить прыжок
            //if (Input.GetButton("Jump"))
            //{
            //    moveDirection.y = jumpSpeed;
            //}
        }
        
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        controller.Move(moveDirection * Time.deltaTime);
        */
    }
}

