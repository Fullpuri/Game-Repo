using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAgeManage : MonoBehaviour
{
    [Header("NPC�̍ŏ��N��")]
    public int m_NPCMinAge;
    [Header("NPC�̍ō��N��")]
    public int m_NPCMaxAge;

    [Header("���g�̔N��")]
    public int m_Age;

    // Start is called before the first frame update
    void Start()
    {
        //���g�̔N��
        m_Age = Random.Range(m_NPCMinAge, m_NPCMaxAge);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
