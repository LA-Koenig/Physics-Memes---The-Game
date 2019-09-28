using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionCat : MonoBehaviour
{
	public GameObject liveCat;
	public GameObject deadCat;
	public float angleDegrees;

	void OnCollisionEnter(Collision other)
	{
            if (other.gameObject.tag == "Player")
           {
		int random = Random.Range(0,2);
		Debug.Log("Random number is " + random);
		if(random==1){
			Instantiate(liveCat, gameObject.transform.position, Quaternion.Euler(0, angleDegrees, 0));
		}
		else{
			Instantiate(deadCat, gameObject.transform.position, Quaternion.Euler(90, angleDegrees, 0));
		}
		Destroy (gameObject);
                //or gameObject.SetActive(false);

           }
	}
}
