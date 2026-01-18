using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameFlowManager gameFlowManager;
	public ArduinoManager arduinoManager_P1;
	public ArduinoManager arduinoManager_P2;
	public UIManager uIManager;
	public static GameManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			Instance = this;
		}
	}
	
	public void CheckIfPlayerIsReady()
	{
		if(gameFlowManager.player1_isReady && gameFlowManager.player2_isReady)
		{
			StartGame();
		}
	}
	
	public void StartGame()
	{
		uIManager.StartGame();
	}
}
