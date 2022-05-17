using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRader : MonoBehaviour
{
    [Header("魔弾移動スクリプト")]
    public MagicMove m_MagicMove;

    //直進時間
    private float StraightTime=0;
    private float m_MyDestoryCnt=0;
    private float m_SystemFrameRate=0;

    // Start is called before the first frame update
    void Start()
    {
        //最初は追尾しない
        this.gameObject.GetComponent<SphereCollider>().enabled = false;

        //ゲーム上のフレームレートを取得
        GameObject m_FrameRateControl= GameObject.Find("FrameRate_Control");
        m_SystemFrameRate = m_FrameRateControl.GetComponent<FrameRate_Control>().SetFrameRate;

        //直進する時間を変換
        StraightTime = this.gameObject.GetComponentInParent<MagicMove>().StraightTime;
        StraightTime *= m_SystemFrameRate;
    }

    // Update is called once per frame
    void Update()
    {
        m_MyDestoryCnt++;
        if (StraightTime < m_MyDestoryCnt)
        {
            //コライダーをアクティブにして追尾させる
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
