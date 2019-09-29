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


    // Start is called before the first frame update
    void Start()
    {
        pObj = GameObject.Find("Player");
        pRb = pObj.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        pC.setSpace();
                  
    }
}
