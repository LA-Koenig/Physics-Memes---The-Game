using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capacitorScript : MonoBehaviour
{
    private GameObject pObj;
    private Vector3 pPos;
    private Rigidbody pRb;
    private PlayerControl pS;
    private Vector3 startPos;

    private float chargeSrength;
    

    // Start is called before the first frame update
    void Start()
    {
        pPos = pObj.transform.position;
        startPos = pObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pPos = pObj.transform.position;

        Debug.Log(pPos);
        // If Cow falls below map
        if (pObj.transform.position.y < -3)

        {
            pObj.transform.position = startPos;
            pRb.velocity = new Vector3(0, 0, 0);
            pRb.angularVelocity = new Vector3(0, 0, 0);
        }

    }
}
