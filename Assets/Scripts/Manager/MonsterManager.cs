using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public enum MonsterType
    {
        none,
        Skar,
        Bulgha,
        Hydralisk
    }
    public class Monster
    {
        public int maxHealt;
        public int maxShield;

        public int currentHealt;
        public int currentShield;

        public MonsterType type;

        public int damageModifier;
        public int shieldModifier;
    }

    public Monster thisMonster;

    public int playerIndex;

    public void SetMonsterType(int _playerIndex, MonsterTypes _monsterType)
    {
        thisMonster.type = _monsterType.type;
        thisMonster.maxHealt = _monsterType.maxHealt;
        thisMonster.maxShield = _monsterType.maxShield;
        thisMonster.damageModifier = _monsterType.damageModifier;
        thisMonster.shieldModifier = _monsterType.shieldModifier;
        playerIndex = _playerIndex;
    }

    public void CheckIfHealtFinish()
    {
        if (thisMonster.currentHealt <= 0)
        {
            // [TODO]
        }
    }

    public void Damaged(int _damage)
    {
        if (thisMonster.currentShield <= 0)
        {
            thisMonster.currentHealt -= _damage;
            CheckIfHealtFinish();
        }

        DamageShield(_damage);
    }

    public void Healed(int _heal)
    {
        if (thisMonster.currentHealt >= thisMonster.maxHealt)
        {
            return;
        }

        if ((thisMonster.currentHealt + _heal) <= thisMonster.maxHealt)
        {
            thisMonster.currentHealt += _heal;
            return;
        }

        if ((thisMonster.currentHealt + _heal) > thisMonster.maxHealt)
        {
            thisMonster.currentHealt = thisMonster.maxHealt;
        }
    }

    public void Defence(int _shield)
    {
        if (thisMonster.currentShield >= thisMonster.maxShield)
        {
            return;
        }

        if ((thisMonster.currentShield + _shield) <= thisMonster.maxShield)
        {
            thisMonster.currentHealt += _shield;
            return;
        }

        if ((thisMonster.currentShield + _shield) > thisMonster.maxShield)
        {
            thisMonster.currentShield = thisMonster.maxShield;
        }
    }

    public void DamageShield(int _damageShield)
    {
        if (_damageShield == 99)
        {
            thisMonster.currentShield = 0;
            return;
        }

        if ((thisMonster.currentShield - _damageShield) >= 0)
        {
            thisMonster.currentShield -= _damageShield;
            return;
        }

        if ((thisMonster.currentShield - _damageShield) < 0)
        {
            int _passtroughtDamage = _damageShield - thisMonster.currentShield;
            thisMonster.currentShield = 0;
            Damaged(_passtroughtDamage);
        }
    }

    public void SelfDamage(int _damage)
    {
        thisMonster.currentHealt -= _damage;
        CheckIfHealtFinish();
    }
}
