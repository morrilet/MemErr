using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SignOffMenu : MonoBehaviour 
{
	AsyncOperation loader;
	
	void Start()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

		loader = SceneManager.LoadSceneAsync ("House");
		loader.allowSceneActivation = false;
	}

	public void Replay()
	{
		loader.allowSceneActivation = true;
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
