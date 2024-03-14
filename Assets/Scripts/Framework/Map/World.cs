using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Map
{

    /// <summary>
    /// to init map and accessory in world
    /// world只是负责生成地图和更新地图，以及触发boss战
    /// </summary>
    public class World
    {
        private IPlayer m_hero;
        private IMap m_currentMap;

        public void InitWorld(IMap currentMap)
        {
            m_currentMap = currentMap;

            m_currentMap.InitMap();
        }

        public void CleanAllEmery()
        {

        }

        public void InitPlayer()
        {

        }

        public void Exit()
        {

        }

    }
}

