using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float speed;
    public Vector3 jump, startPos;
    public bool isGrounded;
    public float jumpForce = 5.0f;

    public float fScale = 2.00f;  // How far is cow launched? 

	public Joystick js;
	List<Touch> mightHaveToJump = new List<Touch>();
	private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        startPos = transform.position;    
    }

    void OnCollisionStay() //double jump (for single comment out this and add in the line in OnCollisionEnter
    {
        isGrounded = true;
    }

    void FixedUpdate ()
    {
        float moveHorizontal = js.Horizontal;
        float moveVertical = js.Vertical;
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement * speed);

	/*
	foreach(Touch touch in Input.touches){
		if (touch.position.x < Screen.width/2)
             {
                 Debug.Log ("Left click");
             }
             else if (touch.position.x > Screen.width/2)
             {
                 Debug.Log ("Right click");
             }
	}
	
	foreach(Touch touch in Input.touches){	
        	if(touch.phase == TouchPhase.Began)
        	{
			mightHaveToJump.Add(touch);
       		 }
		else if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary){
			mightHaveToJump.Remove(touch);
		}
	}
	foreach(Touch touch in mightHaveToJump){
		//if(touch.phase == TouchPhase.Ended){
			//mightHaveToJump.Remove(touch);
			if(isGrounded){
            			rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            			isGrounded = false;
			}
		//}
	}
	*/
    }

    public void launch(Vector3 force)
    {
        print("Launch!");
        rb.AddForce(force * fScale, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
	//isGrounded = true; //If you wanted single jump instead of double
        // If you touch the respawn plane under the map.  reset position
        if (other.gameObject.name == "Respawn_Plane")
        {
            transform.position = startPos;
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0,0,0);
        }
    }

}
