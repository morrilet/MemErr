using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOut : MonoBehaviour 
{
	Text txtObj;
	float fadeTimer = 0f;
	float fadeTime = 7.5f;

	void Start () 
	{
		txtObj = GetComponent<Text> ();
	}

	void Update ()
	{
		Color color = txtObj.color;
		color.a = Mathf.Lerp (255, 0, fadeTimer / fadeTime) / 255f;
		txtObj.color = color;
		Debug.Log (txtObj.color.a);

		if (fadeTimer >= fadeTime)
		{
			Destroy (this.gameObject);
		}

		fadeTimer += Time.deltaTime;
	}
}
