using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeLevel_Trigger : MonoBehaviour 
{
	public string levelToChangeTo;

	AsyncOperation loader;
	void Start()
	{
		loader = SceneManager.LoadSceneAsync (levelToChangeTo);
		loader.allowSceneActivation = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			loader.allowSceneActivation = true;
		}
	}
}
