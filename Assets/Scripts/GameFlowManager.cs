using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public enum GameState
    {
        none,
        Select,
        Resolve
    }

    GameState gameState = GameState.none;

    public int player1_Deck;
    public int player2_Deck;

    public int player1_idCardSelected;
    public int player2_idCardSelected;

    void Setplayer1Deck(int _deckID)
    {
        player1_Deck = _deckID;
    }

    void SetPlayer2Deck(int _deckID)
    {
        player2_Deck -= _deckID;
    }

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
}
