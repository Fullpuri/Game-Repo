using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_NPCs : MonoBehaviour
{
    [Header("�v���C���[�̃I�u�W�F�N�g")]
    public GameObject m_Player;
    [Header("NPC�̃X�|�i�[")]
    public NpcSpowner m_NpcSpowner;

    [Header("���g�̃R���C�_�[")]
    public SphereCollider m_Colider;

    [Header("�����蔻��̔��a")]
    public float CollisonRadius;
    [Header("BigSwing���[�V�������̊g�嗦")]
    public float BigSwingScale;

    [Header("�v���C���[�̃��x���Ǘ��X�N���v�g")]
    public LevelUp m_PlayerLevel;

    [Header("�U���\�ɂȂ�܂ł̎���(�b)")]
    public float Attack_CT_FirstStep=3.0f;
    public float Attack_CT_SecondStep=2.0f;
    private float m_Attack_CT = 0.0f;
    private float m_Attack_CT_Cnt = 0.0f;

    private LevelUp m_LevelUp;

    //���̃X�P�[���̏����l
    private static Vector3 DefaultScale;
    private static float DefaultColRad;
    //�R���W�����̔��a�̏����l
    private static float DefaultColRadius;

    //�v���C���[�̃��x���Ǘ��N���X
    private LevelUp m_PlayerLevelUp;

    private float m_SystemFrameRate = 0;

    // Start is called before the first frame update
    void Start()
    {
        DefaultScale = gameObject.transform.localScale;
        DefaultColRad = m_Colider.radius;

        GameObject m_FPS_Control = GameObject.Find("FrameRate_Control");
        m_SystemFrameRate = m_FPS_Control.GetComponent<FrameRate_Control>().SetFrameRate;
        m_Attack_CT = m_SystemFrameRate * Attack_CT_FirstStep;
    }

    // Update is called once per frame
    void Update()
    {

        //�ŏ��ɕK����A�N�e�B�u�ɂ���
        m_Colider.enabled = false;

        

        if (Input.GetMouseButtonDown(0))
        {
            if (m_Attack_CT < m_Attack_CT_Cnt)
            {
                m_Attack_CT_Cnt = 0;
                AttackModeBranch();
                this.gameObject.GetComponent<AnimationBranch>().SickleAnimationBranch();
            }
        }

        //2�i�K�ڈȍ~�͍U�����x�������Ȃ�
        switch (m_PlayerLevel.GetNowState())
        {
            case (int)Form.State.Second:
            case (int)Form.State.Third:
            case (int)Form.State.Fourth:
            case (int)Form.State.Five:
                m_Attack_CT = m_SystemFrameRate * Attack_CT_SecondStep;
                break;
        }

        m_Attack_CT_Cnt++;


    }

    private void AttackModeBranch()
    {
        m_Colider.enabled = true;

        gameObject.transform.localScale = DefaultScale;

        m_Colider.radius = DefaultColRad;

        switch (m_PlayerLevel.GetNowState())
        {
            case (int)Form.State.First:
            case (int)Form.State.Second:
                break;
            case (int)Form.State.Third:
                break;
            case (int)Form.State.Fourth:
                gameObject.transform.localScale = DefaultScale * BigSwingScale;
                m_Colider.radius *= CollisonRadius;
                break;
            case (int)Form.State.Five:
                gameObject.transform.localScale = DefaultScale * BigSwingScale;
                m_Colider.radius *= CollisonRadius;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_LevelUp = m_Player.GetComponent<LevelUp>();

        //�v���C���[�̔N�� - �E����NPC�̔N��
        int npcAge = collision.gameObject.GetComponent<NpcAgeManage>().m_Age;
        m_LevelUp.m_Age -= npcAge;

        m_NpcSpowner.SubtractionSpownNum();

        Destroy(collision.gameObject);
    }
}
