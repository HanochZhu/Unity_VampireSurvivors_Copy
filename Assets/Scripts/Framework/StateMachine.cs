using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private IState m_currentState;


    public void UpdateState(IState state)
    {
        if(m_currentState != null)
        {
            m_currentState.OnExitState();
        }
        m_currentState = state;
    }

    public void ExitState()
    {
        if(m_currentState != null)
        {
            m_currentState.UpdateState();
        }
    }
}


public interface IState
{
    void OnEnterState();

    void UpdateState();

    void OnExitState();
       
}
