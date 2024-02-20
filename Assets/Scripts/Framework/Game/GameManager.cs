using System.Collections;
using System.Collections.Generic;
using CommonFramework.Runtime;
using UnityEngine;

namespace VS.Framework.Game
{
    public class GameManager : MonoSingleton<GameManager>
    {
        StateMachine game;



        public void StartGame()
        {
            GameSettings.Instance.UpdateGameGlobalSetting();


        }

        public void QuitGame()
        {

        }

        /// <summary>
        /// 切换场景
        /// 主要处理进入副本任务等功能，目前暂时不需要
        /// </summary>
        public void SwitchScene(IScene gameScene)
        {

        }
    }

}

