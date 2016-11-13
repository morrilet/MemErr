using UnityEngine;
using System.Collections;

public class PostIt_Trigger : MonoBehaviour 
{
	public Sprite postItImage;
	Collider triggerColl;
	bool touchingPlayer = false;

	void Start () 
	{
		triggerColl = GetComponent<Collider> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			touchingPlayer = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") 
		{
			touchingPlayer = false;
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
			} 
			else 
			{
				GUI.instance.SetReadAlertActive (true);
			}
		}		
		else
		{
			GUI.instance.SetReadAlertActive (false);
			GUI.instance.SetPostItMenuActive (false, null);
		}
	}
}
