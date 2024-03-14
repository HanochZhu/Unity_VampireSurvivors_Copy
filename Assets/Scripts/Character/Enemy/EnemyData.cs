using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable Object/Enemy Data", order = int.MaxValue)]
public class EnemyData : CreatureData
{
    public ENEMY_TYPE enemyType;

    public ENEMY_ATTACK_TYPE eENEMY_ATTACK_TYPE;
}
