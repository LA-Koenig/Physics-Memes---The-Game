using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
	public string nextScene;

	void OnCollisionEnter(Collision other){
		Debug.Log("You hit a box");
		if(HowManyInList() == 1){
			SceneManager.LoadScene(nextScene);
		}
	}

	int HowManyInList(){
		
		GameObject[] listOfBoxes = GameObject.FindGameObjectsWithTag("Box");
		int sum = 0;
		foreach(GameObject i in listOfBoxes){
			sum ++;
		}
		Debug.Log("There are this many boxes in the scene: " + sum);

		return sum;
	}
}

