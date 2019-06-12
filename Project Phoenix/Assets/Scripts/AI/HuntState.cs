using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Hunt state is used to scare the player by getting the AI as close to the player as possible, forcing the player to hide in fear of being found
/// After hunt state is over the AI will go into patrol state 
/// </summary>

public class HuntState : IEnemyMicroState
{


    private readonly MicroAI m_MicroAI;

    public HuntState(MicroAI microAI)
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
