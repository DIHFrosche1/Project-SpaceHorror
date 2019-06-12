﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
