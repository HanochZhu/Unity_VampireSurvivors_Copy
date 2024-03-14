using System.Collections;
using System.Collections.Generic;
using CommonFramework.Runtime;
using CommonFramework.Runtime.FiniteStateMachine;
using UnityEngine;

namespace VS.Framework.Game
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private StateMachine game;
        private LoginState loginState;
        

        public void StartGame()
        {
            InitService();

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

        private void InitService()
        {

        }
    }
}

