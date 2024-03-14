using System.Collections;
using System.Collections.Generic;
using CommonFramework.Runtime.FiniteStateMachine;
using UnityEngine;

public class GameState : IState
{
    private float gameTime;

    public GameState()
    {

    }

    public void OnStateEnter()
    {
        EnemySystem.CreateInstance();
    }

    public void OnStateExit()
    {
        EnemySystem.DestroyInstance();
    }

    public void OnStateUpdate()
    {
        // this.gameTime += deltaTime;

        EnemySystem.Instance.UpdateEnemySystem(this.gameTime);
    }

}
