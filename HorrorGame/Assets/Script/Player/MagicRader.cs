using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRader : MonoBehaviour
{
    [Header("���e�ړ��X�N���v�g")]
    public MagicMove m_MagicMove;

    //���i����
    private float StraightTime=0;
    private float m_MyDestoryCnt=0;
    private float m_SystemFrameRate=0;

    // Start is called before the first frame update
    void Start()
    {
        //�ŏ��͒ǔ����Ȃ�
        this.gameObject.GetComponent<SphereCollider>().enabled = false;

        //�Q�[����̃t���[�����[�g���擾
        GameObject m_FrameRateControl= GameObject.Find("FrameRate_Control");
        m_SystemFrameRate = m_FrameRateControl.GetComponent<FrameRate_Control>().SetFrameRate;

        //���i���鎞�Ԃ�ϊ�
        StraightTime = this.gameObject.GetComponentInParent<MagicMove>().StraightTime;
        StraightTime *= m_SystemFrameRate;
    }

    // Update is called once per frame
    void Update()
    {
        m_MyDestoryCnt++;
        if (StraightTime < m_MyDestoryCnt)
        {
            //�R���C�_�[���A�N�e�B�u�ɂ��Ēǔ�������
            this.gameObject.GetComponent<SphereCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ref GameObject m_Target= ref m_MagicMove.GetTargetObject();
        if (!m_Target)
        {
            if (other.gameObject.tag == "Enemy")
            {
                m_Target = other.gameObject;
            }
        }
    }
}
