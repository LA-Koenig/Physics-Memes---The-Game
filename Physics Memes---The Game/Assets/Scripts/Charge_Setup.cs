using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge_Setup : MonoBehaviour
{
    public GameObject pObj;     // player gameObject
    public Rigidbody pRb;       // player RigidBody
    public Vector3 pPos;        // player Position
    public PlayerControl pC;    // player Controller Script
    public CameraController cC;    // camera Controller Script
    
    public float pCharge;       // Player Charge
    public float eConst;


    // Start is called before the first frame update
    void Start()
    {
        /*
        pObj = GameObject.Find("Player");
        pRb = pObj.GetComponent<Rigidbody>();
        pC = (PlayerControl)pObj.GetComponent(typeof(PlayerControl));
        cC = (CameraController)GameObject.Find("Main Camera").GetComponent(typeof(CameraController));
        cC.inSpace = true;

        eField = Random.Range(7.0f, 16.0f);
        eConst = 10.0f;

        foreach (GameObject box in listBox)
        {
            Vector3 dPos = new Vector3(-box.transform.position.y + playerObj.transform.position.y, box.transform.position.x - playerObj.transform.position.x, 0.0f);
            box.GetComponent<Rigidbody>().velocity = dPos * velScale;
            box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y, playerObj.transform.position.z);
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        pC.setSpace();

    }
}
