using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card_Action", menuName = "Scriptable Objects/Card_Action")]
public class Card_Action : ScriptableObject
{
    public enum CardLogic
    {
        none,
        Heal,
        Damage,
        Defence,
        SelfDamage,
        EnemyHeal
    }

    public string cardLogicName;

    public Dictionary<CardLogic, int> action = new();
}
