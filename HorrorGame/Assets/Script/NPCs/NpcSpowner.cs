using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpowner : MonoBehaviour
{

    [Header("NPC�̃X�|�[���n�_")]
    public GameObject m_SpawnPointObj;
    [Header("�X�|�[���\��NPC�̍ő吔")]
    public int m_MaxNPC;

    [Header("���݃X�|�[������NPC�̐�")]
    private int m_NowSpownNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�X�|�[���\�ȍő�l�𒴂��Ă��Ȃ��Ȃ�
        if (m_NowSpownNum < m_MaxNPC)
        {
            GameObject obj = (GameObject)Resources.Load("NPCs/TT_demo_female");

            Vector3 spPoint = m_SpawnPointObj.gameObject.transform.position;

            //NPC�̃C���X�^���X�̐���
            Instantiate(
                obj,
                new Vector3(spPoint.x, spPoint.y, spPoint.z),
                Quaternion.identity);

            

            m_NowSpownNum++;
        }
    }
    
    //���Z���s��
    //��x�̌Ăяo���ɑ΂���-1
    public void SubtractionSpownNum()
    {
        m_NowSpownNum -= 1;
    }

    public int GetSpownNum()
    {
        return m_NowSpownNum;
    }
}
