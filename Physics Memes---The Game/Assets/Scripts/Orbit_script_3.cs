using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit_script_3 : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject catObjPrefab;
    public List<GameObject> listBox;
    public Rigidbody playerRb;
    public PlayerControl pC;

    public float r;
    public float angScale;
    public float velScale;
    public float gravScale;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("In space setup script");
        playerObj = GameObject.Find("Player");
        playerRb = playerObj.GetComponent<Rigidbody>();
        Vector3 pPos = playerObj.transform.position;
        pC = (PlayerControl)playerObj.GetComponent(typeof(PlayerControl));

        pC.inSpace = true;
        pC.setSpace();

        r = 10.0f;
        angScale = 1.0f;
        velScale = 1.0f;

        // For perfect circular orbit I think. 
        gravScale = 300.0f;

        for (int i = 0; i < 8; i++)
        {
            GameObject box = Instantiate(catObjPrefab);
            box.transform.localScale = new Vector3( 1.8f, 1.8f, 1.8f);
            box.GetComponent<Rigidbody>().useGravity = false;
            box.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-angScale, angScale), Random.Range(-angScale, angScale), Random.Range(-angScale, angScale));
            box.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
            listBox.Insert(i, box);
        }

        listBox[0].transform.position = new Vector3(pPos.x + r, pPos.y + 0, 0);
        listBox[1].transform.position = new Vector3(pPos.x + 0, pPos.y + r, 0);
        listBox[2].transform.position = new Vector3(pPos.x - r, pPos.y + 0, 0);
        listBox[3].transform.position = new Vector3(pPos.x + 0, pPos.y - r, 0);
        
        
        listBox[4].transform.position = new Vector3(pPos.x + r, pPos.y + r, 0);
        listBox[5].transform.position = new Vector3(pPos.x - r, pPos.y + r, 0);
        listBox[6].transform.position = new Vector3(pPos.x + r, pPos.y - r, 0);
        listBox[7].transform.position = new Vector3(pPos.x - r, pPos.y - r, 0);
        

        // Apply random velocity rotation to boxes


        foreach (GameObject box in listBox)
        {
            Vector3 dPos = new Vector3(- box.transform.position.y + playerObj.transform.position.y, box.transform.position.x - playerObj.transform.position.x , 0.0f );
            box.GetComponent<Rigidbody>().velocity = dPos * velScale;
            box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y, playerObj.transform.position.z);
        }
        
    }
    

    // Update is called once per frame
    void Update()
    {
        pC.setSpace();

        // Give boxes a gravitational attraction torwards the cow
        foreach (GameObject box in listBox)
        {
            if (box != null)
            {
                Vector3 accel = new Vector3(playerObj.transform.position.x - box.transform.position.x, playerObj.transform.position.y - box.transform.position.y, 0.0f);
                float rMag = accel.magnitude;
                box.GetComponent<Rigidbody>().AddForce( accel * gravScale/(rMag*rMag));
                box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y, playerObj.transform.position.z);
            }

        }


    }
}
