using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : IEnemyMicroState
{

    const float m_GiveUpTimerDelta = 5f;
    float m_GiveUpTimer;

    public Transform m_LastKnowPosition;

    private readonly MicroAI m_MicroAI;

    public ChaseState(MicroAI microAI)
    {
        m_MicroAI = microAI;
    }

    public void Enter()
    {
        m_MicroAI.m_agent.speed = m_MicroAI.m_ChaseSpeed;
    }

    public void UpdateState()
    {
        ChasePlayer();
    }

    public void OnTriggernEnter(Collider other)
    {

    }

    public void MoveToState(IEnemyMicroState state)
    {
        m_MicroAI.m_currentAIState = state;
        m_MicroAI.m_currentAIState.Enter();
    }

    void ChasePlayer()
    {
        if (m_MicroAI.CanSeePlayer())
        {
            m_LastKnowPosition = m_MicroAI.m_PlayerToHunt.transform;
            m_GiveUpTimer = 5;
        }
        else
        {
            m_GiveUpTimer -= Time.deltaTime;
            if(m_GiveUpTimer < 0)
            {
                MoveToState(m_MicroAI.m_HuntState);
            }
        }

        m_MicroAI.m_agent.SetDestination(m_LastKnowPosition.position);
        m_MicroAI.m_agent.isStopped = false;
    }
}
