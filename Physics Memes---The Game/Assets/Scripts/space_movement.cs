using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class space_movement : MonoBehaviour
{
    public GameObject playerObj;
    public Rigidbody playerRb;
    public PlayerControl pC;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("In space setup script");
        playerObj = GameObject.Find("Player");
        playerRb = playerObj.GetComponent<Rigidbody>();
        pC = (PlayerControl)playerObj.GetComponent(typeof(PlayerControl));

        pC.inSpace = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
