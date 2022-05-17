using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Move : MonoBehaviour
{

    [Header("������͈�")]
    public float m_EscapeRange;

    public NavMeshAgent m_Player;
    private NavMeshHit m_NavMeshHit;

    public float SamplePos_MaxDistance;
    public int SamplePos_AreaMask;

    [Header("NPC�̎��S�G�t�F�N�g")]
    public GameObject DeathEffect;

    [Header("NPC�̃X�|�i�[")]
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

        //pathPending �o�H�T���̏����ł��Ă��邩�ǂ���
        if (!m_Player.pathPending)
        {
            if (m_Player.remainingDistance <= m_Player.stoppingDistance)
            {
                //hasPath �G�[�W�F���g���o�H�������Ă��邩�ǂ���
                //navMeshAgent.velocity.sqrMagnitude�̓X�s�[�h
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
        //SamplePosition�͐ݒ肵���ꏊ����5�͈̔͂ōł��߂�������Bake���ꂽ�ꏊ��T���B
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