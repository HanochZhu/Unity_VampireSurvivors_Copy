using UnityEngine;
using System.Collections;

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
    void InitPlayer(CharacterData configData);

    void Attack();

    void Damage(float hurt);
}


public interface IEnemy : ICreatureInterface
{

}

public class CreatureData : ScriptableObject
{
    public string Name;
    public Sprite sprite;
    public int healthPoint;
    public int attackPower;
    public int defencePower;
    public int speed;
    public int maxHealth;
}

public class PlayerData : CreatureData
{
    
}

public class EnemyData : CreatureData
{
    public ENEMY_TYPE enemyType;
}

public enum ENEMY_TYPE
{
    NORMAL,
    ELITE,
    BOSS
}