using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement2 : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;


    // Start is called before the first frame update
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal2") * runSpeed;
        if (Input.GetButtonDown("Jump2"))
        {
            jump = true;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch ,jump);
        jump = false;
    }
}