using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAgeManage : MonoBehaviour
{
    [Header("NPCの最小年齢")]
    public int m_NPCMinAge;
    [Header("NPCの最高年齢")]
    public int m_NPCMaxAge;

    [Header("自身の年齢")]
    public int m_Age;

    // Start is called before the first frame update
    void Start()
    {
        //自身の年齢
        m_Age = Random.Range(m_NPCMinAge, m_NPCMaxAge);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
