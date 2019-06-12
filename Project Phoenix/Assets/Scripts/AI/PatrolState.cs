using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

///<summary> 
/// This file simply moves the AI to the patrol state.
/// Patrol state is used to give the player some breathing room for completeting tasks
/// </summary>

public class PatrolState : IEnemyMicroState
{

    private readonly MicroAI m_MicroAI;

    public PatrolState(MicroAI microAI)
    {
        m_MicroAI = microAI;
    }

    public void UpdateState()
    {
       
    }

    public void OnTriggernEnter(Collider other)
    {

    }

    public void MoveToState(IEnemyMicroState state)
    {
        m_MicroAI.m_currentAIState = state;
    }
}
