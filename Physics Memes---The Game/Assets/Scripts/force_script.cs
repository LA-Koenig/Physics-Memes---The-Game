using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force_script : MonoBehaviour
{
    Vector3 pos1, pos2;

    GameObject playerObj;

    public PlayerControl playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
        playerScript = (PlayerControl) playerObj.GetComponent(typeof(PlayerControl));
    }

    // Update is called once per frame
    void Update()
    {
        // Inital Mouse press
        if (Input.GetMouseButtonDown(0))
        {
            //pos1 = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y, (float)(Camera.main.nearClipPlane + 0.5));
            pos1 = playerObj.transform.position;
            //pos1 = Camera.main.ScreenToWorldPoint(pos1);
            pos2 = pos1;
        }

        // While mouse is held
        if (Input.GetMouseButton(0))
        {
            pos2 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerObj.transform.position.z);
            pos2 = Camera.main.ScreenToWorldPoint(pos2);
        }

        // once released
        if (Input.GetMouseButtonUp(0))
        {
            pos1 = playerObj.transform.position;
            pos2 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerObj.transform.position.z);
            pos2 = Camera.main.ScreenToWorldPoint(pos2);
            Vector3 force = pos2 - pos1;
            playerScript.launch(force);
            Destroy(gameObject);
        }

        if (pos2 != pos1)
        {
            var v3 = pos2 - pos1;
            transform.position = pos1 + (v3) * 0.5f;
            transform.localScale = new Vector3( transform.localScale.x, v3.magnitude*.5f, transform.localScale.z);
            transform.rotation = Quaternion.FromToRotation(Vector3.up, v3);
        }
    }

}
