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
    public float bCharge;       // box Charge
    GameObject[] listBox;
    public float velScale;

    //public List<GameObject> listBox;


    // Start is called before the first frame update
    void Start()
    {
        
        pObj = GameObject.Find("Player");
        pRb = pObj.GetComponent<Rigidbody>();
        pC = (PlayerControl)pObj.GetComponent(typeof(PlayerControl));
        cC = (CameraController)GameObject.Find("Main Camera").GetComponent(typeof(CameraController));
        cC.inSpace = true;

        pObj.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.red);

        bCharge = 5.0f;
        pCharge = 10.0f;

        velScale = 0.2f;

        listBox = GameObject.FindGameObjectsWithTag("Box");

        foreach (GameObject box in listBox)
        {
            Vector3 dPos = new Vector3(-box.transform.position.y + pObj.transform.position.y, box.transform.position.x - pObj.transform.position.x, 0.0f);
            box.GetComponent<Rigidbody>().velocity = dPos * velScale;

            box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y, pObj.transform.position.z);
            if((int)(box.GetInstanceID() * 0.1f) % 2 == 0)
            {
                box.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.red);
            }
            else
            {
                box.GetComponentInChildren<MeshRenderer>().material.SetColor("_Color", Color.blue);
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        pC.setSpace();
        // Give boxes a gravitational attraction torwards the cow

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                pCharge = -pCharge;

                if (pCharge > 0.0f)
                    pObj.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.red);
                else
                    pObj.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.blue);
            }

        }

        foreach (GameObject box in listBox)
        {
            if (box != null)
            {
                Vector3 rVect = new Vector3(pObj.transform.position.x - box.transform.position.x, pObj.transform.position.y - box.transform.position.y, 0.0f);
                Vector3 totForce = new Vector3(0, 0, 0);
                float rMag = rVect.magnitude;
                float accelMag = bCharge * pCharge / (rMag * rMag);
                if ((int)(box.GetInstanceID() * 0.1f) % 2 == 0)
                {
                    accelMag = -accelMag;
                }
                totForce += rVect * accelMag;
                box.GetComponent<Rigidbody>().AddForce(rVect * accelMag);
                box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y, pObj.transform.position.z);

                foreach (GameObject boxj in listBox)
                {
                    if (boxj != null && (box.GetInstanceID() != boxj.GetInstanceID()))
                    {
                        rVect = new Vector3(boxj.transform.position.x - box.transform.position.x, boxj.transform.position.y - box.transform.position.y, 0.0f);
                        rMag = rVect.magnitude;
                        accelMag = bCharge * bCharge / (rMag * rMag);
                        if ((int)(boxj.GetInstanceID() * 0.1f) % 2 != (int)(box.GetInstanceID()%2))
                        {
                            accelMag = -accelMag;
                        }
                        totForce += rVect * accelMag;
                    }

                }


                box.GetComponent<Rigidbody>().AddForce(totForce);

            }

        }
    }
}
