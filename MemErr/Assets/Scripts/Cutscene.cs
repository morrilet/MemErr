using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Cutscene : MonoBehaviour 
{
	MovieTexture tex;
	AsyncOperation loader;

	void Awake()
	{
		float camHeight = Camera.main.orthographicSize * 2;
		float camWidth = camHeight * Screen.width / Screen.height;

		Vector3 scale = transform.localScale;
		scale.x = camWidth;
		scale.y = camHeight;
		transform.localScale = scale;
	}

	void Start()
	{
		loader = SceneManager.LoadSceneAsync ("SignOff");
		loader.allowSceneActivation = false;

		tex = (MovieTexture)GetComponent<Renderer> ().material.mainTexture;
		tex.Play ();
		StartCoroutine (WaitToChangeLevel (15.53f)); //15.53 is the length of the clip. For some reason, we couldn't save that data to the movie file.
	}

	IEnumerator WaitToChangeLevel(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		loader.allowSceneActivation = true;
	}
}
