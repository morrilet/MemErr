using UnityEngine;
using System.Collections;

public class PostIt_Trigger : MonoBehaviour 
{
	public Sprite postItImage;
	Collider triggerColl;
	bool touchingPlayer = false;

	bool firstUse = true;
	bool used = false;

	void Start () 
	{
		triggerColl = GetComponent<Collider> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			touchingPlayer = true;
			Debug.Log("Here");
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") 
		{
			touchingPlayer = false;
			GUI.instance.SetReadAlertActive (false);
			GUI.instance.SetPostItMenuActive (false, null);

			if (firstUse && used) 
			{
				firstUse = false;
				GameManager.instance.StartNextEvent ();
			}
		}
	}

	void Update () 
	{
		if (touchingPlayer) 
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				GUI.instance.SetPostItMenuActive (true, postItImage);
				GUI.instance.SetReadAlertActive (false);

				used = true;
			} 
			else 
			{
				GUI.instance.SetReadAlertActive (true);
			}
		}
	}
}
