using UnityEngine;
using UnityEngine.UI;
using static MonsterManager;

[CreateAssetMenu(fileName = "MonsterTypes", menuName = "Scriptable Objects/MonsterTypes")]
public class MonsterTypes : ScriptableObject
{
    public string monsterName;
    public Sprite monsterImage;

    public int maxHealt;
    public int maxShield;

    public MonsterType type;

    public int damageModifier;
    public int shieldModifier;
}
