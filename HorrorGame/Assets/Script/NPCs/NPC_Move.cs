using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Move : MonoBehaviour
{

    [Header("逃げる範囲")]
    public float m_EscapeRange;

    public NavMeshAgent m_Player;
    private NavMeshHit m_NavMeshHit;

    public float SamplePos_MaxDistance;
    public int SamplePos_AreaMask;

    [Header("NPCの死亡エフェクト")]
    public GameObject DeathEffect;

    [Header("NPCのスポナー")]
    private GameObject m_NpcSpowner;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = gameObject.GetComponent<NavMeshAgent>();
        m_NpcSpowner = GameObject.Find("NPCs");
    }

    // Update is called once per frame
    void Update()
    {

        //pathPending 経路探索の準備できているかどうか
        if (!m_Player.pathPending)
        {
            if (m_Player.remainingDistance <= m_Player.stoppingDistance)
            {
                //hasPath エージェントが経路を持っているかどうか
                //navMeshAgent.velocity.sqrMagnitudeはスピード
                if (!m_Player.hasPath || m_Player.velocity.sqrMagnitude == 0f)
                {
                    SetDestination();
                }
            }
        }
    }

    void SetDestination()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(-m_EscapeRange, m_EscapeRange),
            0,
            Random.Range(-m_EscapeRange, m_EscapeRange));
        //SamplePositionは設定した場所から5の範囲で最も近い距離のBakeされた場所を探す。
        NavMesh.SamplePosition
            (randomPos,
            out m_NavMeshHit,
            SamplePos_MaxDistance,
            SamplePos_AreaMask);
        m_Player.destination = m_NavMeshHit.position;
    }

    private void OnDestroy()
    {
        if (m_NpcSpowner)
        {
            Instantiate(
                DeathEffect,
                this.gameObject.transform.position+new Vector3(0,0.1f,0),
                this.gameObject.transform.rotation);

            m_NpcSpowner.GetComponent<NpcSpowner>().SubtractionSpownNum();



        }
    }
}