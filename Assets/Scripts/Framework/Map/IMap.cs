using UnityEngine;

namespace Framework.Map
{
    /// <summary>
    /// 我们需要确定地图的更新方向，以及地图的图集
    /// 地图图解首先肯定是2x2的地图
    /// leftup      rightup
    /// leftdown    rightdown
    /// 这样才能实现无缝卷轴
    /// 中心点是0，0点
    ///
    /// 同时map中需要定义每一关boss，并且定义boss的和小怪的逻辑
    /// </summary>
    public interface IMap
    {
        protected void ConfigMap(MapData data);

        internal IEnemy GetConfigedEnemy();

        internal void EnterHiddenRoom(IPlayer player, IMap hiddenRoom);

        void InitMap();

        MAP_TYPE GetMapType();

        IEnemy CallBoss(int number);

        /// <summary>
        /// 根据当前位置刷新地图，地图使用滚轴无穷地图
        /// </summary>
        /// <param name="Pos"></param>
        void UpdateMap(Vector2Int Pos);

        void DisposeMap();
    }

    public enum MAP_TYPE
    {
        MAP,
        EMBED_MAP
    }

}
