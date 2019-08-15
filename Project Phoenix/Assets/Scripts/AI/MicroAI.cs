using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MicroAI : MonoBehaviour
{

    public int m_FieldOfView = 180;
    public int m_MaxViewDistance = 10;
    public int m_PatrolSpeed;
    public int m_HuntSpeed;
    public int m_ChaseSpeed;
    public Transform m_Eye;
    public GameObject m_PlayerToHunt;
    public List<Vector3> m_PointsOfInterest = new List<Vector3>();
    public Transform[] m_PatrolPoints;

    public IEnemyMicroState m_currentAIState;
    [HideInInspector] public ChaseState m_ChaseState;
    [HideInInspector] public HuntState m_HuntState;
    [HideInInspector] public PatrolState m_PatrolState;

    public NavMeshAgent m_agent;
    Animator m_anim;

    void Start()
    {
        m_ChaseState = new ChaseState(this);
        m_HuntState = new HuntState(this);
        m_PatrolState = new PatrolState(this);

        m_currentAIState = m_PatrolState;
        m_currentAIState.Enter();

        m_agent = GetComponent<NavMeshAgent>();
        m_anim = GetComponent<Animator>();

    }

    void Update()
    {
        m_anim.SetFloat("Blend", m_agent.desiredVelocity.magnitude);
        m_currentAIState.UpdateState();
        Vector3 direction = m_PlayerToHunt.transform.position - m_Eye.position;
        Debug.DrawRay(m_Eye.position, direction);
        Debug.Log(m_currentAIState);
    }

    private void OnTriggerEnter(Collider other)
    {
        m_currentAIState.OnTriggernEnter(other);
    }

    public bool CanSeePlayer()
    {

        RaycastHit hit;

        Vector3 direction = m_PlayerToHunt.transform.position - m_Eye.position;

        if (Physics.Raycast(m_Eye.position, direction, out hit, m_MaxViewDistance))
        {
            var hitObj = hit.collider.gameObject;

            if (hitObj.CompareTag("Player") && Vector3.Angle(transform.forward, direction) > -45 && Vector3.Angle(transform.forward, direction) < 45)
            {
                Debug.Log(hitObj);
                return true;
            }
        }

        return false;
    }


}
