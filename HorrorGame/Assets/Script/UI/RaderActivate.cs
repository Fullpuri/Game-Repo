using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaderActivate : MonoBehaviour
{
    [Header("レーダー用のカメラ")]
    public GameObject m_Rader;

    [Header("プレイヤーのレベル管理スクリプト")]
    private LevelUp m_PlayerLevel = null;


    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーのレベルスクリプトを取得
        GameObject m_PlayerObj = GameObject.Find("Player");
        m_PlayerLevel = m_PlayerObj.GetComponent<LevelUp>();

        m_Rader.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //RaderActivateコンポーネントのみ削除する
        if (m_PlayerLevel.GetNowState()== (int)Form.State.Five)
        { 
            Destroy(this.gameObject.GetComponent<RaderActivate>());
        }
    }

    private void OnDestroy()
    {
        m_Rader.gameObject.SetActive(true);
    }
}
