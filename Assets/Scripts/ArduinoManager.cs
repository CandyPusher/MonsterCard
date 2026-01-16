using System;
using System.IO.Ports;
using UnityEngine;

public class ArduinoManager : MonoBehaviour
{
    [Header("Connessione")]
    [SerializeField] string PORT = "COM3";
    [SerializeField] int BAUD = 9600;
    [SerializeField] int readingSpeed = 50;

    [Header("Riferimenti")]
    [SerializeField] int playerIndex = 1;

    private SerialPort sp;

    private void Awake()
    {
        sp = new SerialPort(PORT, BAUD);
        sp.ReadTimeout = readingSpeed;
    }

    private void Start()
    {
        try { sp.Open(); }
        catch (Exception e) { Debug.LogError("Errore porta seriale: " + e.Message); }
    }

    private void Update()
    {
        if (sp == null || !sp.IsOpen) return;

        try
        {
            string incomingData = sp.ReadLine().Trim();

            if (incomingData == "Pressed")
            {
                GameManager.Instance.gameFlowManager.PlayerInteracted(playerIndex);
                Debug.Log($"Input: {incomingData}");
                return;
            }

            string[] parts = incomingData.Split('-');

            if (parts.Length == 2)
            {
                if (int.TryParse(parts[0], out int cardID) && int.TryParse(parts[1], out int deckID))
                {
                    HandleInput(cardID, deckID);
                }
            }
        }
        catch (TimeoutException) { }
        catch (Exception e) { Debug.LogWarning("Errore lettura: " + e.Message); }
    }

    private void HandleInput(int cardID, int deckID)
    {
        Debug.Log($"Carta: {cardID} | Deck: {deckID}");

        if (cardID == 0)
        {
            GameManager.Instance.gameFlowManager.setPlayerDeck(playerIndex, deckID);
            return;
        }
        else
        {
            switch (deckID)
            {
                case 1:
                    HandleFistDeck(cardID);
                    break;
                case 2:
                    HandleSecondDeck(cardID);
                    break;
                case 3:
                    HandleThirdDeck(cardID);
                    break;
            }
            return;
        }
    }

    private void HandleFistDeck(int _cardID)
    {
        switch (_cardID)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
        }
    }

    private void HandleSecondDeck(int _cardID)
    {
        switch (_cardID)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
        }
    }

    private void HandleThirdDeck(int _cardID)
    {
        switch (_cardID)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
        }
    }

    private void OnApplicationQuit()
    {
        if (sp != null && sp.IsOpen) sp.Close();
    }
}