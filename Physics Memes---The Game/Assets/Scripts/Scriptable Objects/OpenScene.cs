using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SceneController/NewScene")]
//[MenuItem("Assets/Create/My Scriptable Object/OpenScene")]
public class OpenScene : ScriptableObject
{
	public string nextScene;

	public void NextScene(){
		SceneManager.LoadScene(nextScene);
	}	
}
