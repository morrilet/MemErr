using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PostIt_Menu : MonoBehaviour 
{
	public Image postItImage;
	public Image backgroundImage;
	public Button backButton;

	void SetImage(Sprite img)
	{
		postItImage.sprite = img;
	}

	public void StartMenu(Sprite img)
	{
		SetImage (img);
		//postItImage.enabled = false;
		//backgroundImage.enabled = false;
		//backButton.enabled = false;
	}

	public void ExitMenu()
	{
		GUI.instance.SetPostItMenuActive (false, null);
		//postItImage.enabled = false;
		//backgroundImage.enabled = false;
		//backButton.enabled = false;
	}
}
