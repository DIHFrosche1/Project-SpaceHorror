using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroAI : MonoBehaviour
{

    public int m_FieldOfView = 180;
    public int m_MaxViewDistance = 10;
    public int m_PatrolSpeed;
    public int m_HuntSpeed;
    public int m_ChaseSpeed;
    public Transform m_Eye;
    public List<Vector3> m_PointsOfInterest = new List<Vector3>();

    [HideInInspector] public IEnemyMicroState m_currentAIState;
    [HideInInspector] public ChaseState m_ChaseState;
    [HideInInspector] public HuntState m_HuntState;
    [HideInInspector] public PatrolState m_PatrolState;


    void Start()
    {
        m_ChaseState = new ChaseState(this);
        m_HuntState = new HuntState(this);
        m_PatrolState = new PatrolState(this);

        m_currentAIState = m_PatrolState;
    }

    void Update()
    {
        m_currentAIState.UpdateState();
    }

    private void OnTriggerEnter(Collider other)
    {
        m_currentAIState.OnTriggernEnter(other);
    }
}
