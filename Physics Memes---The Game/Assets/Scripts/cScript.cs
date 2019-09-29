using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cScript : MonoBehaviour
{
    private float lBound, rBound;
    public GameObject pObj;     // player gameObject
    public Rigidbody pRb;       // player RigidBody
    public Vector3 pPos;        // player Position
    public PlayerControl pC;    // player Controller Script
    public CameraController cC;    // camera Controller Script
    public capacitorScript cS;    // Capacitor Script

    public Vector3 capPos;       // Capacitor Position
    public Vector3 capScale;     // Capacitor Scale

    public float eField;        // Electrical Field Strength
    public float pCharge;       // Player Charge
    public float accel;


    // Start is called before the first frame update
    void Start()
    {
        pObj = GameObject.Find("Player");
        pRb = pObj.GetComponent<Rigidbody>();
        pC = (PlayerControl)pObj.GetComponent(typeof(PlayerControl));
        cC = (CameraController)GameObject.Find("Main Camera").GetComponent(typeof(CameraController));
        cS = (capacitorScript)GameObject.Find("Capacitor_Setup").GetComponent(typeof(capacitorScript));

        eField = Random.Range(7.0f, 16.0f);
        cC.inSpace = true;

        capPos = transform.position;
        capScale = transform.localScale;
        Debug.Log(gameObject.name);
        Debug.Log(gameObject.transform.rotation);

        // Upside down capacitor
        if ( gameObject.name == "Cap_Down")
        {
            eField = -eField;
        } 
        
        rBound = capPos.x + capScale.x;
        lBound = capPos.x - capScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        pC.setSpace();
        pPos = pObj.transform.position;

        if ( !(lBound >= pPos.x) && (pPos.x <= rBound) )  // This is the opposite of what I thought...
        {
            Debug.Log("Inside Field!");
            accel = -eField * cS.pCharge;
            pRb.AddForce(0.0f, accel, 0.0f);
        }
        else
        {
            //Debug.Log("Outside Field...");
        }
    }
}
