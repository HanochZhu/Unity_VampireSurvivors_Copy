using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// It's the base class for all creature like monster, player, boss.
/// 
/// </summary>
public interface ICreatureInterface
{
    void Init(CreatureData configedData);
    /// <summary>
    /// move to position. 
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="time"></param>
    void MoveTo(Vector3 pos, float time);

    void MoveStraight();

    void Dead();
}

public interface IPlayer : ICreatureInterface
{
    /// <summary>
    /// Init player, set different player data, generate different player
    /// </summary>
    void InitPlayer(CreatureData configData);

    void Attack();

    void Damage(float hurt);
}


public interface IEnemy : ICreatureInterface
{

}

public class CreatureData : ScriptableObject
{
    public enum CharacterType
    {
        FlyingEye,
        Goblin,
        Skeleton,
        Mushroom,
        Knight,
        Bandit
    }


    [SerializeField] RuntimeAnimatorController controller;
    [SerializeField] CharacterType characterType;
    [SerializeField] string Name;
    [SerializeField] Sprite sprite;
    [SerializeField] int healthPoint;
    [SerializeField] int attackPower;
    [SerializeField] int defencePower;
    [SerializeField] int speed;
    [SerializeField] int maxHealth;
    [SerializeField] IWeapon DefauleWeapon;
    [SerializeField] List<IWeapon> holdingWeapon;

    public int GetHealthPoint()
    {
        return healthPoint;
    }

    public int GetAttackPower()
    {
        return attackPower;
    }

    public int GetDefencePower()
    {
        return defencePower;
    }

    public int GetSpeed()
    {
        return speed;
    }

    public CharacterType GetCharacterType()
    {
        return characterType;
    }

    public RuntimeAnimatorController GetController()
    {
        return controller;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }
}

public class PlayerData : CreatureData
{
    
}



public enum ENEMY_TYPE
{
    NORMAL,
    ELITE,
    BOSS
}

public enum ENEMY_ATTACK_TYPE
{
    /// <summary>
    /// 最普通的，拿脸撞
    /// </summary>
    TOWARD,
    /// <summary>
    /// 围绕着进行远程攻击
    /// </summary>
    ARROUND_ATTACK,
    /// <summary>
    /// 靠近后放技能
    /// </summary>
    TOWARD_AND_ATTACK

}