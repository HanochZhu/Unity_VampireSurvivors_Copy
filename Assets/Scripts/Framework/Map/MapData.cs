using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class MapData : ScriptableObject
    {
        /// <summary>
        /// Position
        /// GameObject : map Chunk Prefab
        /// </summary>
        public Dictionary<Vector2Int, GameObject> mapImageConfig;

        public List<EnemySpawnConfigItem> EnemySpawnConfigs;
    }

    /// <summary>
    /// 什么时候生成什么样的怪
    /// 这个基本上可以涵盖所有的怪物生成设置了
    /// </summary>
    public class EnemySpawnConfigItem : ScriptableObject
    {
        public float time;// second
        /// <summary>
        /// 这种怪物出现的持续时间
        /// 如果是-1，那么就是一直等到下一个怪物出现
        /// </summary>
        public float lastTime = -1;

        /// <summary>
        /// 给策划提供怪物出场时类型的控制
        /// </summary>
        public EnemySpawnEvent SpawnEvent;
        /// <summary>
        /// 可以在同一时刻出现多种怪物
        /// 当然也可以是一种
        /// </summary>
        public List<EnemyData> SpawnEnemy;
    }

    public enum EnemySpawnEvent
    {
        /// <summary>
        /// 普通，一个一个出
        /// </summary>
        Normal,
        /// <summary>
        /// 开始从四周往中间围拢
        /// </summary>
        Wave,
        /// <summary>
        /// 扫过
        /// </summary>
        Sweep,
        /// <summary>
        /// 该怪物出现时，其他怪物也会消失
        /// 一般用于boss
        /// </summary>
        Singular
    }
}
