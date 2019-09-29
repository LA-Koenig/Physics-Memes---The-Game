using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capacitorScript : MonoBehaviour
{
    public GameObject pObj;
    public Vector3 pPos;
    public Rigidbody pRb;
    public PlayerControl pS;
    public Vector3 startPos;

    private float chargeSrength;
    

    // Start is called before the first frame update
    void Start()
    {
        pPos = pObj.transform.position;
        pRb = pObj.GetComponent<Rigidbody>();
        pS = (PlayerControl)pObj.GetComponent(typeof(PlayerControl));
        startPos = pObj.transform.position;
        pS.setSpace();
    }

    // Update is called once per frame
    void Update()
    {
        pS.setSpace();
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
