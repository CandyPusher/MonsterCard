using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	GameObject ui_mainMenu;
	
	public void StartGame()
	{
		ui_mainMenu.SetActive(false);
	}
}