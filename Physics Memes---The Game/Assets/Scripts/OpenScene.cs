using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 1)]
//[MenuItem("Assets/Create/My Scriptable Object/OpenScene")]
public class OpenScene : ScriptableObject
{
	public string nextScene;

	public void NextScene(){
		SceneManager.LoadScene(nextScene);
	}	
}
