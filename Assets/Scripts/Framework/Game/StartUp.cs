using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VS.Framework.Game
{
    /// <summary>
    /// This is enter of game
    /// We need to ensure each can run respective, 
    /// </summary>
    public class StartUp : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GameManager.Instance.StartGame();
        }
    }

}
