using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionCat : MonoBehaviour
{
	public GameObject prefab;

	void OnCollisionEnter(Collision other)
	{
            if (other.gameObject.tag == "Player")
           {

		Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
		Destroy (gameObject);
                //or gameObject.SetActive(false);

           }
	}
}
