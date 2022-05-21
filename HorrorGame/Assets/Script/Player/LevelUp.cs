using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Form
{
    //�`�Ԃ̏��
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

    //�n�ʂɐڒn���Ă��邩�ǂ���
    public bool m_isGround=false;

    //���@�����p�J�E���^
    float m_cnt=0;

    [Header("�Q�[���J�n���̔N��")]
    public int GameStateAge = 9999;
    [Header("1�i�K�ڂ̍Œ�N��")]
    public int FirstStepAgeLevel=9800;
    [Header("2�i�K�ڂ̍Œ�N��")]
    public int SecondStepAgeLevel = 9400;
    [Header("3�i�K�ڂ̍Œ�N��")]
    public int ThirdStepAgeLevel= 8200;
    [Header("4�i�K�ڂ̍Œ�N��")]
    public int FourthStepAgeLevel = 6600;
    [Header("5�i�K�ڂ̍Œ�N��")]
    public int FiveStepAgeLevel = 20;

    [Header("���_�̔N��")]
    public int m_Age = 9999;
    [Header("�W�����v��")]
    public float m_jumpPower = 0;


    //�`�Ԃ̏�ԕϐ�
    private Form.State m_NowState= Form.State.First;

    // Start is called before the first frame update
    void Start()
    {
        //�N��̏�����
        m_Age = GameStateAge;
        m_levelUp = GetComponent<FPSCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        //�������
        if (m_Age > FirstStepAgeLevel)
        {
            m_NowState = Form.State.First;
        }
        //���i�K
        else if(m_Age > SecondStepAgeLevel)
        {
            m_NowState = Form.State.Second;
        }
        //��O�i�K
        else if (m_Age > ThirdStepAgeLevel)
        {
            m_NowState = Form.State.Third;
        }
        //��l�i�K
        else if (m_Age > FourthStepAgeLevel)
        {
            m_NowState = Form.State.Fourth;
        }
        //�ŏI�`��
        else
        {
            m_NowState = Form.State.Five;
        }

        //������
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
        //�X�y�[�X�L�[�ŕ��V
        if (Input.GetKey(KeyCode.Space))
        {
            m_levelUp.m_rigidbody.useGravity = false;
           
        }
        //E�L�[�ŉ���
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_levelUp.m_rigidbody.useGravity = true;
        }

        
    }

    private void FormBranch()
    {
        //��Ԃ̒i�K�̐������s��
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
                        //�󒆕��V
                        floating();
                    }
                    continue;
                case ((int)Form.State.Fourth):
                    {
                        m_cnt++;

                        //�E�N���b�N��������
                        if (Input.GetMouseButton(1) && m_cnt % 5 == 0)
                        {
                            //�J�����̍��W��������Ă�������ɒe�𔭎�
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
