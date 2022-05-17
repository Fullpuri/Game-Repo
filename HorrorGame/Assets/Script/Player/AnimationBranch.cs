using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBranch : MonoBehaviour
{

    Animator m_animator;

    [Header("プレイヤーのレベル管理スクリプト")]
    public LevelUp m_PlayerLevel;


    //最初のフレーム更新の前にStartが呼び出されます
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    //更新はフレームごとに1回呼び出されます
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
