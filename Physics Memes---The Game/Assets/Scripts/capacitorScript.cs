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

    public Material blueCow;
    public Material redCow;

    public float pCharge;
    

    // Start is called before the first frame update
    void Start()
    {
        pObj = GameObject.Find("Player");
        pPos = pObj.transform.position;
        pRb = pObj.GetComponent<Rigidbody>();
        pS = (PlayerControl)pObj.GetComponent(typeof(PlayerControl));
        startPos = pObj.transform.position;
        pS.setSpace();
        pCharge = 5.0f;
        pObj.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.red);

    }

    // Update is called once per frame
    void Update()
    {
        pS.setSpace();

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                pCharge = - pCharge;

                if (pCharge > 0.0f)
                    pObj.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.red);
                else
                    pObj.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.blue);
            }

        }
    }
}
