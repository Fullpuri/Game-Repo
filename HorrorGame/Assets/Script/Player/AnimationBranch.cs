using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBranch : MonoBehaviour
{

    Animator m_animator;

    [Header("�v���C���[�̃��x���Ǘ��X�N���v�g")]
    public LevelUp m_PlayerLevel;


    //�ŏ��̃t���[���X�V�̑O��Start���Ăяo����܂�
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    //�X�V�̓t���[�����Ƃ�1��Ăяo����܂�
    void Update()
    {

    }

    public void SickleAnimationBranch()
    {
        switch (m_PlayerLevel.GetNowState())
        {
            case (int)Form.State.First:
                m_animator.SetTrigger("Swing");
                break;

            case (int)Form.State.Second:
                m_animator.SetTrigger("Throw");
                break;
            case (int)Form.State.Third:
            case (int)Form.State.Fourth:
            case (int)Form.State.Five:
                m_animator.SetTrigger("BigSwing");
                break;
        }
    }
}
