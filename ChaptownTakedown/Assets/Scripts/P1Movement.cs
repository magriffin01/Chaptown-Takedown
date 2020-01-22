using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Movement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump;
    bool crouch;

    void Start()
    {
        jump = false;
        crouch = false;
    }

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

    //Destroy Panther Buck When Touched
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Panther Buck"))
        {
            Destroy(other.gameObject);
        }
    }
}