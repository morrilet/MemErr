using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> 
{
	public GameObject player;
	public GameObject PostIt_1, PostIt_2, PostIt_3, PostIt_4;
	public GameObject recordPlayer;
	public GameObject frontDoor;

	private int currentEvent = 0; //What event we're on. EX: event 4 turns on the record player.

	void Start ()
	{
		Cursor.visible = false;

		PostIt_1.SetActive (false);
		PostIt_2.SetActive (false);
		PostIt_3.SetActive (false);
		PostIt_4.SetActive (false);
		frontDoor.GetComponent<Door> ().isOpen = false;

		StartNextEvent ();
	}

	void Update()
	{
		//if (Input.GetKeyDown (KeyCode.Y)) 
		//{
		//	StartNextEvent ();
		//}
	}

	public void StartNextEvent()
	{
		currentEvent += 1;
		switch (currentEvent) 
		{
		case 1:
			PostIt_1.SetActive (true);
			PostIt_1.GetComponent<PostIt_Alert> ().PlayAlert ();
			break;
		case 2:
			PostIt_2.SetActive (true);
			PostIt_2.GetComponent<PostIt_Alert> ().PlayAlert ();
			break;
		case 3:
			PostIt_3.SetActive (true);
			PostIt_3.GetComponent<PostIt_Alert> ().PlayAlert ();
			break;
		case 4:
			recordPlayer.GetComponent<RecordPlayer_Controller> ().PlayLoops (7);
			PostIt_4.SetActive (true);
			PostIt_4.GetComponent<PostIt_Alert> ().PlayAlert ();
			break;
		case 5:
			frontDoor.GetComponent<Door> ().isOpen = true;
			break;
		}
	}
}
