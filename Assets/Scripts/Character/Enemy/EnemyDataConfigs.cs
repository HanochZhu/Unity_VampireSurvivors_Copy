using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// a collection of enemy data
/// </summary>
[CreateAssetMenu(fileName = "Enemy Data Configs", menuName = "Scriptable Object/Enemy Data Configs", order = int.MaxValue)]
public class EnemyDataConfigs : ScriptableObject
{
    public List<EnemyData> enemyDatas;
}
