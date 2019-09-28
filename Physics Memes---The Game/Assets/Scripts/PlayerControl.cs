﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float speed;
    public Vector3 jump, startPos;
    private Rigidbody rb;
    public bool isGrounded;
    public float jumpForce = 5.0f;

    public float fScale = 2.00f;  // How far is cow launched? 

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        startPos = transform.position;    
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement * speed);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    public void launch(Vector3 force)
    {
        print("Launch!");
        rb.AddForce(force * fScale, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {

        // If you touch the respawn plane under the map.  reset position
        if (other.gameObject.name == "Respawn_Plane")
        {
            transform.position = startPos;
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0,0,0);
        }
    }

}
