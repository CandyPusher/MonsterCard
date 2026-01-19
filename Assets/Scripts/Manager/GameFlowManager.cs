using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
	public enum GameState
	{
		none,
		characterSelection,
		gameSetup,
		Select,
		Resolve
	}

	GameState gameState = GameState.none;

	public int player1_Deck;
	public int player2_Deck;

	public int player1_idCardSelected;
	public int player2_idCardSelected;

	public bool player1_isReady;
	public bool player2_isReady;

	private void Start()
	{
		gameState = GameState.characterSelection;
	}
	
	#region StartGame Menu
	
	#region player1

	[SerializeField]
	Creature_SpriteManager player1_Creature;

	private void Setplayer1Deck(int _deckID)
	{
		if (!player1_isReady)
		{
			player1_Deck = _deckID;
			player1_Creature.UpdateCreature(_deckID);
		}
	}

	[SerializeField]
	Selection_Banner player1Banner;

	private void Player1ToggleSelection()
	{
		if (player1_Deck == 0)
		{
			return;
		}

		player1_isReady = !player1_isReady;

		if (player1_isReady)
		{
			player1Banner.SetSelectionColor();
		}
		else
		{
			player1Banner.SetMyColor();
		}
	}

	#endregion

	#region player2

	[SerializeField]
	Creature_SpriteManager player2_Creature;

	private void SetPlayer2Deck(int _deckID)
	{
		if (!player2_isReady)
		{
			player2_Deck = _deckID;
			player2_Creature.UpdateCreature(_deckID);
		}
	}

	[SerializeField]
	Selection_Banner player2Banner;

	private void Player2ToggleSelection()
	{
		if (player2_Deck == 0)
		{
			return;
		}

		player2_isReady = !player2_isReady;

		if (player2_isReady)
		{
			player2Banner.SetSelectionColor();
		}
		else
		{
			player2Banner.SetMyColor();
		}
	}

	#endregion

	public void setPlayerDeck(int _playerID, int _deckID)
	{
		if (_playerID == 1)
		{
			Setplayer1Deck(_deckID);
		}
		else if (_playerID == 2)
		{
			SetPlayer2Deck(_deckID);
		}
	}

	public void PlayerInteracted(int _playerIndex)
	{
		if (gameState == GameState.characterSelection)
		{
			if (_playerIndex == 1)
			{
				Player1ToggleSelection();
			}
			else if (_playerIndex == 2)
			{
				Player2ToggleSelection();
			}

			GameManager.Instance.CheckIfPlayerIsReady();
		}
	}
	
	#endregion
	
	public void StartSequence()
	{
		setPlayerCreature();
		GameManager.Instance.uIManager.StartGame();
	}
	
	private void setPlayerCreature()
	{
		
	}
	
}
