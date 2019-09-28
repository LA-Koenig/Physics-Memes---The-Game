using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCat : MonoBehaviour
{
	public float speed;

	private void FixedUpdate(){
		gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
	}
}
