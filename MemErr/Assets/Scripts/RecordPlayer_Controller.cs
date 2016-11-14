using UnityEngine;
using System.Collections;

public class RecordPlayer_Controller : MonoBehaviour 
{
	public AudioClip clipToPlay;

	AudioSource source;

	void Start()
	{
		source = GetComponent<AudioSource> ();
		this.GetComponent<RecordPlayer> ().recordPlayerActive = false;
	}

	public void PlayLoops(int numLoops)
	{
		StartCoroutine(PlayLoop (numLoops));
	}

	IEnumerator PlayLoop(int numLoops)
	{
		this.GetComponent<RecordPlayer> ().recordPlayerActive = true;
		for (int i = 0; i < numLoops; i++) 
		{
			source.PlayOneShot (clipToPlay);
			yield return new WaitForSeconds (clipToPlay.length);
		}
		this.GetComponent<RecordPlayer> ().recordPlayerActive = false;
	}
}
