using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgeCounter : MonoBehaviour
{
    [Header("プレイヤーの年齢")]
    public TextMeshProUGUI m_AgeCountText=null;
    [Header("詳細な情報の表示")]
    public TextMeshProUGUI m_AgeDetailsInfo = null;

    private int m_Age=0;

    [Header("プレイヤーのレベル管理スクリプト")]
    private LevelUp m_PlayerLevel = null;


    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーのレベルスクリプトを取得
        GameObject m_PlayerObj = GameObject.Find("Player");
        m_PlayerLevel = m_PlayerObj.GetComponent<LevelUp>();
    }

    // Update is called once per frame
    void Update()
    {

        m_Age = GameObject.Find("Player").GetComponent<LevelUp>().m_Age;
        m_AgeCountText.text = string.Format("{0}歳", m_Age);

        switch (m_PlayerLevel.GetNowState())
        {
            case (int)Form.State.First:
                {
                    m_AgeDetailsInfo.text = string.Format(
                        "現在のレベル:1" +
                        "\n現在開放中の能力:" +
                        "\n鎌" +

                        "\n次で開放:" +
                        "\n鎌の強化" +
                        "\n移動速度上昇");
                    break;
                }
            case (int)Form.State.Second:
                {
                    m_AgeDetailsInfo.text = string.Format(
                        "現在のレベル:2" +
                        "\n現在開放中の能力:" +
                        "\n鎌の強化" +
                        "\n移動速度上昇" +

                        "\n次で開放:" +
                        "\n浮遊");
                    break;
                }
            case (int)Form.State.Third:
                {
                    m_AgeDetailsInfo.text = string.Format(
                        "現在のレベル:3" +
                        "\n現在開放中の能力:" +
                        "\n鎌の強化" +
                        "\n移動速度上昇" +
                        "\n浮遊" +

                        "\n次で開放:" +
                        "\n壁貫通" +
                        "\n鎌の巨大化");
                    break;
                }
            case (int)Form.State.Fourth:
                {
                    m_AgeDetailsInfo.text = string.Format(
                        "現在のレベル:4" +
                        "\n現在開放中の能力:" +
                        "\n鎌の強化" +
                        "\n移動速度上昇" +
                        "\n浮遊" +
                        "\n壁貫通" +
                        "\n鎌の巨大化" +

                        "\n次で開放:" +
                        "\nミニマップ" +
                        "\nエネルギー弾");
                    break;
                }
            case (int)Form.State.Five:
                {
                    m_AgeDetailsInfo.text = string.Format(
                        "現在のレベル:5" +
                        "\n現在開放中の能力:" +
                        "\n鎌の強化" +
                        "\n移動速度上昇" +
                        "\n浮遊" +
                        "\n壁貫通" +
                        "\n鎌の巨大化" +
                        "\nミニマップ" +
                        "\nエネルギー弾" +

                        "\nレベル上限に到達");
                    break;
                }
        }
    }
}
