using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class space_setup_3 : MonoBehaviour
{
    private GameObject playerObj;
    private Rigidbody playerRb;
    private PlayerControl pC;
    private float angScale;
    private float velScale;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("In space setup script");
        playerObj = GameObject.Find("Player");
        playerRb = playerObj.GetComponent<Rigidbody>();
        pC = (PlayerControl)playerObj.GetComponent(typeof(PlayerControl));

        pC.inSpace = true;
        pC.setSpace();

        angScale = 1.0f;
        velScale = 2.5f;

         // Apply random velocity / rotation to boxes

        GameObject[] listOfBoxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (GameObject i in listOfBoxes)
        {
            i.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-angScale, angScale), Random.Range(-angScale, angScale), Random.Range(-angScale, angScale));
            i.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-velScale, velScale), Random.Range(-velScale, velScale), Random.Range(-velScale, velScale));
        }
    }

    // Update is called once per frame
    void Update()
    {
        pC.setSpace();
    }
}
