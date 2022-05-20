using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlider : MonoBehaviour
{
    [Header("レベルをスライダーで表現したオブジェクト")]
    private Slider LevelGaugeComponent=null;

    [Header("プレイヤーのレベル管理スクリプト")]
    private LevelUp m_PlayerLevel=null;

    // Start is called before the first frame update
    void Start()
    {
        //レベルのスライダーオブジェクトを取得
        GameObject m_LevelGaugeObj = GameObject.Find("LevelGauge");
        LevelGaugeComponent = m_LevelGaugeObj.GetComponent<Slider>();

        //プレイヤーのレベルスクリプトを取得
        GameObject m_PlayerObj = GameObject.Find("Player");
        m_PlayerLevel = m_PlayerObj.GetComponent<LevelUp>();
    }

    // Update is called once per frame
    void Update()
    {
        //現在の状態によってスライダーの下限と上限を変更する 
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

        //スライダー上の値を年齢に応じて更新
        LevelGaugeComponent.value = m_PlayerLevel.m_Age;

        //下限を下回らないようにする
        if (m_PlayerLevel.m_Age < m_PlayerLevel.FiveStepAgeLevel)
        {
            m_PlayerLevel.m_Age = m_PlayerLevel.FiveStepAgeLevel;
        }
    }
}
