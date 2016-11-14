using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class GUI : Singleton<GUI>
{
	[SerializeField]
	private GameObject readPostItAlert;
	[SerializeField]
	private GameObject postItMenu;

	FirstPersonController playerController;
	Vector2 startingMouseLookSensitivity;
	float startingWalkSpeed, startingRunSpeed;

	void Start()
	{
		readPostItAlert.SetActive (false);
		postItMenu.SetActive (false);

		playerController = GameObject.FindWithTag("Player").GetComponent<FirstPersonController> ();
		startingMouseLookSensitivity.x = playerController.m_MouseLook.XSensitivity;
		startingMouseLookSensitivity.y = playerController.m_MouseLook.YSensitivity;
		startingWalkSpeed = playerController.m_WalkSpeed;
		startingRunSpeed = playerController.m_RunSpeed;
	}

	public void SetReadAlertActive(bool active)
	{
		readPostItAlert.SetActive (active);
	}

	public void SetPostItMenuActive(bool active, Sprite postItImage)
	{
		postItMenu.GetComponent<PostIt_Menu> ().StartMenu (postItImage);
		postItMenu.SetActive (active);

		if (active) 
		{
			playerController.m_MouseLook.SetCursorLock (false);
			playerController.m_MouseLook.XSensitivity = .15f;
			playerController.m_MouseLook.YSensitivity = .15f;
			Cursor.visible = true;

			playerController.m_WalkSpeed = 0;
			playerController.m_RunSpeed = 0;
		} 
		else 
		{
			playerController.m_MouseLook.SetCursorLock (true);
			playerController.m_MouseLook.XSensitivity = startingMouseLookSensitivity.x;
			playerController.m_MouseLook.YSensitivity = startingMouseLookSensitivity.y;
			Cursor.visible = false;

			playerController.m_WalkSpeed = startingWalkSpeed;
			playerController.m_RunSpeed = startingRunSpeed;
		}	
	}
}
