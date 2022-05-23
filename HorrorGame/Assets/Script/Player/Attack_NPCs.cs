using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_NPCs : MonoBehaviour
{
    [Header("プレイヤーのオブジェクト")]
    public GameObject m_Player;
    [Header("NPCのスポナー")]
    public NpcSpowner m_NpcSpowner;

    [Header("自身のコライダー")]
    public SphereCollider m_Colider;

    [Header("当たり判定の半径")]
    public float CollisonRadius;
    [Header("BigSwingモーション時の拡大率")]
    public float BigSwingScale;

    [Header("プレイヤーのレベル管理スクリプト")]
    public LevelUp m_PlayerLevel;

    [Header("攻撃可能になるまでの時間(秒)")]
    public float Attack_CT_FirstStep=3.0f;
    public float Attack_CT_SecondStep=2.0f;
    private float m_Attack_CT = 0.0f;
    private float m_Attack_CT_Cnt = 0.0f;

    private LevelUp m_LevelUp;

    //鎌のスケールの初期値
    private static Vector3 DefaultScale;
    private static float DefaultColRad;
    //コリジョンの半径の初期値
    private static float DefaultColRadius;

    //プレイヤーのレベル管理クラス
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

        //最初に必ず非アクティブにする
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

        //2段階目以降は攻撃速度が早くなる
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

        //プレイヤーの年齢 - 殺したNPCの年齢
        int npcAge = collision.gameObject.GetComponent<NpcAgeManage>().m_Age;
        m_LevelUp.m_Age -= npcAge;

        m_NpcSpowner.SubtractionSpownNum();

        Destroy(collision.gameObject);
    }
}
