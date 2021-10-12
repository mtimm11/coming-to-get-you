using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        float currentRunSpeed = runSpeed;

        //Prevents strafe abuse which would make the player unreasonably fast
        if(horizontal != 0 && vertical != 0)
        {
            currentRunSpeed = (float)(Math.Sqrt(Math.Pow(runSpeed, 2)/2));
        }
        body.velocity = new Vector2(horizontal * currentRunSpeed, vertical * currentRunSpeed);
    }
}
