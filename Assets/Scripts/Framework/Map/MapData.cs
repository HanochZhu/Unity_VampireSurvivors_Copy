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

        public List<EnemySpawnConfig> EnemySpawnConfigs;
    }

    /// <summary>
    /// 什么时候生成什么样的怪
    /// 这个基本上可以涵盖所有的怪物生成设置了
    /// </summary>
    public class EnemySpawnConfig : ScriptableObject
    {
        public float time;// second
        public List<EnemyData> SpawnEnemy;
    }
}
