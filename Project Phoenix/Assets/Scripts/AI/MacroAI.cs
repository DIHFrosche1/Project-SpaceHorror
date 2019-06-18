using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacroAI : MonoBehaviour
{

    public GameObject m_MicroAIObj;

    private float m_WaitTimer = 5;
    private MicroAI m_MicroAI;

    void Start()
    {
        m_MicroAI = m_MicroAIObj.GetComponent<MicroAI>();
    }

    void Update()
    {
        if (m_MicroAI.m_currentAIState == m_MicroAI.m_PatrolState)
            GiveMicroPatrolPoints();
    }

    void GiveMicroPatrolPoints()
    {
        var microAgent = m_MicroAI.m_agent;

        if (microAgent.remainingDistance < 1 && microAgent.pathPending == false)
        {
            m_WaitTimer -= Time.deltaTime;
            microAgent.isStopped = true;
            if (m_WaitTimer < 0)
            {
                int randomPatrolPoint = Random.Range(0, m_MicroAI.m_PatrolPoints.Length);
                microAgent.SetDestination(m_MicroAI.m_PatrolPoints[randomPatrolPoint].position);
                m_WaitTimer = 5;
                microAgent.isStopped = false;
            }
        }
    }

    void GiveMicroPosition(Vector3 position)
    {
        m_MicroAI.m_PatrolState.PatrolOnPoint(position);
    }
}
