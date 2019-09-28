using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{

    public GameObject trajPointPrefab;
    public GameObject ballPref;

    public GameObject ball;
    public bool isPressed, isBallThrown;
    public float throwPower = 100f;
    public int nPoints = 10;
    public List<GameObject> trajPoints;

    public GameObject playerObj;
    public Rigidbody playerRb;
    public PlayerControl pC;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
        playerRb = playerObj.GetComponent<Rigidbody>();
        trajPoints = new List<GameObject>();
        isPressed = isBallThrown = false;

        for (int i=0; i<nPoints; i++)
        {
            GameObject dot = (GameObject)Instantiate(trajPointPrefab);
            dot.GetComponent<Renderer>().enabled = false;
            trajPoints.Insert(i, dot);
        }

        playerRb.velocity = new Vector3(0, 0, 0);
        playerRb.angularVelocity = new Vector3(0, 0, 0);
        playerRb.useGravity = false;
        pC = (PlayerControl)playerObj.GetComponent(typeof(PlayerControl));
        pC.noControl();
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 vel = GetForceFrom(playerObj.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
        setTrajectoryPoints(playerObj.transform.position, vel / playerRb.mass);

        
        if (Input.GetMouseButtonUp(0))
        {
            playerRb.useGravity = true;
            throwCow();
            Destroy(gameObject);            
        }


    }

    //---------------------------------------	
    private void throwCow()
    {
        Vector3 force = GetForceFrom(playerObj.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        playerRb.AddForce(force, ForceMode.Impulse);
    }

    //---------------------------------------	
    private Vector3 GetForceFrom(Vector3 fromPos, Vector3 toPos)
    {
        return ((new Vector3(toPos.x, toPos.y) - new Vector3(fromPos.x, fromPos.y)) * throwPower);
    }

    void setTrajectoryPoints(Vector3 pStartPosition, Vector3 pVelocity)
    {
        float velocity = Mathf.Sqrt((pVelocity.x * pVelocity.x) + (pVelocity.y * pVelocity.y));
        float angle = Mathf.Rad2Deg * (Mathf.Atan2(pVelocity.y, pVelocity.x));
        float fTime = 0;

        fTime += 0.1f;
        for (int i = 0; i < nPoints; i++)
        {
            float dx = velocity * fTime * Mathf.Cos(angle * Mathf.Deg2Rad);
            float dy = velocity * fTime * Mathf.Sin(angle * Mathf.Deg2Rad) - (Physics.gravity.magnitude * fTime * fTime / 2.0f);
            Vector3 pos = new Vector3(pStartPosition.x + dx, pStartPosition.y + dy, playerObj.transform.position.z);
            trajPoints[i].transform.position = pos;
            trajPoints[i].GetComponent<Renderer>().enabled = true;
            trajPoints[i].transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(pVelocity.y - (Physics.gravity.magnitude) * fTime, pVelocity.x) * Mathf.Rad2Deg);
            fTime += 0.1f;
        }
    }
}
