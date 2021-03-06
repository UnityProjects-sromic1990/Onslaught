using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SeekPlayer : MonoBehaviour
{
    private GameObject m_Player;
    private NavMeshAgent m_NavMeshAgent;

    private float m_UpdatePeriod = 0.25f;
    private float m_Timer = 0f;

    private void Start()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer -= Time.deltaTime;

        if (m_Timer <= 0f)
        {
            UpdateNavMeshAgent();

            m_Timer = m_UpdatePeriod;
        }
    }

    void UpdateNavMeshAgent()
    {
        if (m_Player == null)
        {
            m_Player = GameManager.instance.player;
            if (m_Player == null)
                return;
        }

        m_NavMeshAgent.destination = m_Player.transform.position;
    }
}
