using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SceneController/NewScene")]
public class OpenScene : ScriptableObject
{
	public string nextScene;

	public void NextScene(){
		SceneManager.LoadScene(nextScene);
	}	
}
