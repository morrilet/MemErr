using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	public bool isOpen;
	bool isOpenPrev;

	float timeToChangeStates = .75f;
	float openAngle = 80;
	float closedAngle = 0;

	AudioSource source;
	public AudioClip stateChangeClip;

	void Start()
	{
		source = GetComponent<AudioSource> ();
	}

	void Update()
	{
		//if (Input.GetKeyDown (KeyCode.G)) 
		//{
		//	isOpen = !isOpen;
		//}

		if (isOpen != isOpenPrev) 
		{
			if (source.isPlaying)
				source.Stop ();
			
			source.PlayOneShot (stateChangeClip);
		}

		Quaternion newRot = transform.rotation;
		if (isOpen) 
		{
			if (Mathf.Abs (Mathf.Abs (transform.rotation.eulerAngles.y) - Mathf.Abs (openAngle)) > .001f) 
			{
				newRot = Quaternion.Lerp (transform.rotation, Quaternion.AngleAxis (openAngle, Vector3.down), Time.deltaTime * 2);
			}
		} 
		else 
		{
			if (Mathf.Abs (Mathf.Abs (transform.rotation.eulerAngles.y) - Mathf.Abs (closedAngle)) > .001f)
			{
				newRot = Quaternion.Lerp (transform.rotation, Quaternion.AngleAxis (closedAngle, Vector3.down), Time.deltaTime * 2);
			}
		}
		transform.rotation = newRot;

		isOpenPrev = isOpen;
	}
}
