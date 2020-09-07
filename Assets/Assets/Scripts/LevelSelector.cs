using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour {

	void OnMouseDown()
	{
		SceneManager.LoadScene(gameObject.name, LoadSceneMode.Single);

	}
	
}
