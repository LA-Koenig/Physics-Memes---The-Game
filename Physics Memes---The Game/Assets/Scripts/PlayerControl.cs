using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    
    public float speed;
    private Rigidbody rb;
    public Vector3 jump, startPos;
    public bool isGrounded;

    public bool inSpace;
    public float spaceSpeed;
    public bool canControl;
	public Joystick js;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;

        // Default
        speed = 5.0f;
        jump = new Vector3(0.0f, 10.0f, 0.0f);
        canControl = true;
        inSpace = false;
        spaceSpeed = 10.0f;
    }

    void OnCollisionStay() //double jump (for single comment out this and add in the line in OnCollisionEnter
    {
        if (!inSpace)
        {
            isGrounded = true;
        }
    }

    void FixedUpdate ()
    {

        //controls movement on ground
        if (canControl && !inSpace){
			float jHorizontal = js.Horizontal;
            float moveHorizontal = Input.GetAxis("Horizontal");
			Vector3 movement = new Vector3(0,0,0);
			if (Mathf.Abs(jHorizontal) >= Mathf.Abs(moveHorizontal))
			{
				movement.x = jHorizontal;
			}
			else {
				movement.x = moveHorizontal;
			}            
            rb.AddForce(movement * speed);
        }


        // If cow jumps
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !inSpace)
        {
            rb.AddForce(jump, ForceMode.Impulse);
            isGrounded = false;
        }
		
		foreach(Touch touch in Input.touches ){	
				if((touch.phase == TouchPhase.Began) && isGrounded && ! inSpace)
				{
						rb.AddForce(jump , ForceMode.Impulse);
						isGrounded = false;
				 }
		
        }

        // Controls in space
        if (inSpace)
        {			
			float jHorizontal = js.Horizontal;
			float jVertical = js.Vertical;
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
			
			Vector3 movement = new Vector3( 0, 0, 0 );
			if ( Mathf.Abs(jHorizontal) >= Mathf.Abs(moveHorizontal))
			{
				movement.x = jHorizontal;
			}
			else {
				movement.x = moveHorizontal;
			}
            
            if (Mathf.Abs(jVertical) >= Mathf.Abs(moveVertical))
            {
                movement.y = jVertical;
            }
            else
            {
                movement.y = moveVertical;
            }

            rb.AddForce(movement * spaceSpeed);
        }

        // If Cow falls below map
        if (transform.position.y < -3)
        {
            resetPos();
        }

    }

    public void resetPos()
    {
        transform.position = startPos;
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);
    }

    public void noControl()
    {
        Debug.Log("Calling no control");
        canControl = false;
    }

    public void setSpace()
    {
        Debug.Log("Telling cow it's in space.");
        inSpace = true;
    }

}
