using UnityEngine;
using System.Collections;

public class PostIt_Alert : MonoBehaviour
{
	public AudioClip alertClip;
	AudioSource source;

	void Awake()
	{
		source = GetComponent<AudioSource> ();
		source.clip = alertClip;
	}

	public void PlayAlert()
	{
		source.PlayOneShot (alertClip);
	}
}
