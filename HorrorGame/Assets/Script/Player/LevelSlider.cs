using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlider : MonoBehaviour
{
    [Header("���x�����X���C�_�[�ŕ\�������I�u�W�F�N�g")]
    private Slider LevelGaugeComponent=null;

    [Header("�v���C���[�̃��x���Ǘ��X�N���v�g")]
    private LevelUp m_PlayerLevel=null;

    // Start is called before the first frame update
    void Start()
    {
        //���x���̃X���C�_�[�I�u�W�F�N�g���擾
        GameObject m_LevelGaugeObj = GameObject.Find("LevelGauge");
        LevelGaugeComponent = m_LevelGaugeObj.GetComponent<Slider>();

        //�v���C���[�̃��x���X�N���v�g���擾
        GameObject m_PlayerObj = GameObject.Find("Player");
        m_PlayerLevel = m_PlayerObj.GetComponent<LevelUp>();
    }

    // Update is called once per frame
    void Update()
    {
        //���݂̏�Ԃɂ���ăX���C�_�[�̉����Ə����ύX���� 
        switch (m_PlayerLevel.GetNowState())
        {
            case (int)Form.State.First:
                {
                    LevelGaugeComponent.maxValue = m_PlayerLevel.GameStateAge;
                    LevelGaugeComponent.minValue = m_PlayerLevel.FirstStepAgeLevel;
                    break;
                }
            case (int)Form.State.Second:
                {
                    LevelGaugeComponent.maxValue = m_PlayerLevel.FirstStepAgeLevel;
                    LevelGaugeComponent.minValue = m_PlayerLevel.SecondStepAgeLevel;
                    break;
                }
            case (int)Form.State.Third:
                {
                    LevelGaugeComponent.maxValue = m_PlayerLevel.SecondStepAgeLevel;
                    LevelGaugeComponent.minValue = m_PlayerLevel.ThirdStepAgeLevel;
                    break;
                }
            case (int)Form.State.Fourth:
                {
                    LevelGaugeComponent.maxValue = m_PlayerLevel.ThirdStepAgeLevel;
                    LevelGaugeComponent.minValue = m_PlayerLevel.FourthStepAgeLevel;
                    break;
                }
            case (int)Form.State.Five:
                {
                    LevelGaugeComponent.maxValue = m_PlayerLevel.FourthStepAgeLevel;
                    LevelGaugeComponent.minValue = m_PlayerLevel.FiveStepAgeLevel;
                    break;
                }
        }

        //�X���C�_�[��̒l��N��ɉ����čX�V
        LevelGaugeComponent.value = m_PlayerLevel.m_Age;

        //�����������Ȃ��悤�ɂ���
        if (m_PlayerLevel.m_Age < m_PlayerLevel.FiveStepAgeLevel)
        {
            m_PlayerLevel.m_Age = m_PlayerLevel.FiveStepAgeLevel;
        }
    }
}
