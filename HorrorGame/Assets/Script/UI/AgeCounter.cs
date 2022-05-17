using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgeCounter : MonoBehaviour
{
    [Header("プレイヤーの年齢")]
    public TextMeshProUGUI m_AgeText=null;

    private int m_Age=0;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        m_Age = GameObject.Find("Player").GetComponent<LevelUp>().m_Age;
        m_AgeText.text = string.Format("{0}歳", m_Age);
    }
}
