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

    private const float m_SpotTimer = 1;
    private float m_timer;


    public PatrolState(MicroAI microAI)
    {
        m_MicroAI = microAI;
    }

    public void Enter()
    {
        m_MicroAI.m_agent.speed = m_MicroAI.m_PatrolSpeed;
        m_timer = m_SpotTimer;
    }

    public void UpdateState()
    {
        ReactIfSawPlayer();
    }

    public void OnTriggernEnter(Collider other)
    {

    }

    public void MoveToState(IEnemyMicroState state)
    {
        m_MicroAI.m_currentAIState = state;
        m_MicroAI.m_currentAIState.Enter();
    }

    void ReactIfSawPlayer()
    {
        if (m_MicroAI.CanSeePlayer())
        {
            m_MicroAI.m_agent.isStopped = true;
            m_timer -= Time.deltaTime;
            if (m_timer < 0)
                MoveToState(m_MicroAI.m_ChaseState);
        }
        else
        {
            m_MicroAI.m_agent.isStopped = false;
            m_timer = m_SpotTimer;
        }
    }

    public void PatrolOnPoint(Vector3 position)
    {
        var microAgent = m_MicroAI.m_agent;
        microAgent.SetDestination(position);
    }
}
