using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpowner : MonoBehaviour
{

    [Header("NPCのスポーン地点")]
    public GameObject m_SpawnPointObj;
    [Header("スポーン可能なNPCの最大数")]
    public int m_MaxNPC;

    [Header("現在スポーン中のNPCの数")]
    private int m_NowSpownNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //スポーン可能な最大値を超えていないなら
        if (m_NowSpownNum < m_MaxNPC)
        {
            GameObject obj = (GameObject)Resources.Load("NPCs/TT_demo_female");

            Vector3 spPoint = m_SpawnPointObj.gameObject.transform.position;

            //NPCのインスタンスの生成
            Instantiate(
                obj,
                new Vector3(spPoint.x, spPoint.y, spPoint.z),
                Quaternion.identity);

            

            m_NowSpownNum++;
        }
    }
    
    //減算を行う
    //一度の呼び出しに対して-1
    public void SubtractionSpownNum()
    {
        m_NowSpownNum -= 1;
    }

    public int GetSpownNum()
    {
        return m_NowSpownNum;
    }
}
