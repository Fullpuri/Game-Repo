using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Form
{
    //形態の状態
    enum State
    {
        First,
        Second,
        Third,
        Fourth,
        Five,
    }
}

public class LevelUp : MonoBehaviour
{

    private FPSCamera m_levelUp;
    [SerializeField] GameObject magic;

    //地面に接地しているかどうか
    public bool m_isGround=false;

    //魔法制限用カウンタ
    float m_cnt=0;

    [Header("ゲーム開始時の年齢")]
    public int GameStateAge = 9999;
    [Header("1段階目の最低年齢")]
    public int FirstStepAgeLevel=9800;
    [Header("2段階目の最低年齢")]
    public int SecondStepAgeLevel = 9400;
    [Header("3段階目の最低年齢")]
    public int ThirdStepAgeLevel= 8200;
    [Header("4段階目の最低年齢")]
    public int FourthStepAgeLevel = 6600;
    [Header("5段階目の最低年齢")]
    public int FiveStepAgeLevel = 20;

    [Header("死神の年齢")]
    public int m_Age = 9999;
    [Header("ジャンプ力")]
    public float m_jumpPower = 0;


    //形態の状態変数
    private Form.State m_NowState= Form.State.First;

    // Start is called before the first frame update
    void Start()
    {
        //年齢の初期化
        m_Age = GameStateAge;
        m_levelUp = GetComponent<FPSCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        //初期状態
        if (m_Age > FirstStepAgeLevel)
        {
            m_NowState = Form.State.First;
        }
        //第二段階
        else if(m_Age > SecondStepAgeLevel)
        {
            m_NowState = Form.State.Second;
        }
        //第三段階
        else if (m_Age > ThirdStepAgeLevel)
        {
            m_NowState = Form.State.Third;
        }
        //第四段階
        else if (m_Age > FourthStepAgeLevel)
        {
            m_NowState = Form.State.Fourth;
        }
        //最終形態
        else
        {
            m_NowState = Form.State.Five;
        }

        //実処理
        FormBranch();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            m_isGround = true;
        }

        if(other.gameObject.tag=="Enemy")
        {

        }

    }
    public void floating()
    {
        //スペースキーで浮遊
        if (Input.GetKey(KeyCode.Space))
        {
            m_levelUp.m_rigidbody.useGravity = false;
           
        }
        //Eキーで解除
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_levelUp.m_rigidbody.useGravity = true;
        }

        
    }

    private void FormBranch()
    {
        //状態の段階の数だけ行う
        for (int index = 0; index < (int)m_NowState+1; index++)
        {
            switch (index)
            {
                case ((int)Form.State.First):
                    {
                        m_levelUp.m_speed = 0.005f;

                        if (m_isGround)
                        {
                            if (Input.GetKey(KeyCode.Space))
                            {
                                m_isGround = false;
                                m_levelUp.m_rigidbody.AddForce(new Vector3(0, m_jumpPower, 0));
                            }
                        }
                    }
                    continue;
                case ((int)Form.State.Second):
                    {
                        m_levelUp.m_speed = 0.05f;
                    }
                    continue;
                case ((int)Form.State.Third):
                    {
                        //空中浮遊
                        floating();
                    }
                    continue;
                case ((int)Form.State.Fourth):
                    {
                        m_cnt++;

                        //右クリック長押しで
                        if (Input.GetMouseButton(1) && m_cnt % 5 == 0)
                        {
                            //カメラの座標から向いている方向に弾を発射
                            Instantiate(magic,
                                m_levelUp.m_camObj.transform.position,
                                m_levelUp.m_camObj.transform.rotation);
                        }
                    }
                    continue;
                case ((int)Form.State.Five):
                    {

                    }
                    break;
            }
        }
    }

    public int GetNowState()
    {
        return (int)m_NowState;
    }

    void Stop()
    {
        m_levelUp.m_rigidbody.velocity = Vector3.zero;
        m_levelUp.m_rigidbody.angularVelocity = Vector3.zero;
    }
}
