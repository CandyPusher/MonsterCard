using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Card_Base", menuName = "Scriptable Objects/Card_Base")]

public class Card_Base : ScriptableObject
{
    [Header("Card Image")]
    public Sprite card_Image;
    [Header("ID")]
    public int deck_ID;
    public int card_ID;
    [Header("Description")]
    public string card_Name;
    public string card_Description;

    public Card_Action cardType;

    public void ActivateCard(int _playerIndex)
    {
        UseAction(cardType, _playerIndex);
    }

    public void UseAction(Card_Action _cardUtilities, int _playerIndex)
    {
        foreach(var logic in _cardUtilities.action)
        {
            if (logic.Key == Card_Action.CardLogic.Heal)
            {
                Heal(logic.Value, _playerIndex);
            }

            else if (logic.Key == Card_Action.CardLogic.Damage)
            {
                Damage(logic.Value, _playerIndex);
            }

            else if (logic.Key == Card_Action.CardLogic.Defence)
            {
                Defence(logic.Value, _playerIndex);
            }

            else if (logic.Key == Card_Action.CardLogic.SelfDamage)
            {
                SelfDamage(logic.Value, _playerIndex);
            }

            else if (logic.Key == Card_Action.CardLogic.EnemyHeal)
            {
                EnemyDefence(logic.Value, _playerIndex);
            }
        }
    }

    public void Heal(int _value, int _playerIndex)
    {
        Debug.Log(_value);
    }

    public void Damage(int _value, int _playerIndex)
    {
        Debug.Log(_value);
    }

    public void Defence(int _value, int _playerIndex)
    {
        Debug.Log(_value);
    }

    public void SelfDamage(int _value, int _playerIndex)
    {
        Debug.Log(_value);
    }

    public void EnemyDefence(int _value, int _playerIndex)
    {
        Debug.Log(_value);
    }
}