using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMove : MonoBehaviour
{
    private Rigidbody rb;

    [Header("発射速度")]
    public float m_magicSpeed;
    [Header("消滅時間")]
    public float m_deleteTime = 3.0f;
    [Header("直進時間")]
    public float StraightTime=2.0f;

    [Header("追尾するターゲット")]
    private GameObject m_Target = null;

    [SerializeField] GameObject ex;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, m_deleteTime);


    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * m_magicSpeed;
        Instantiate(ex.gameObject, transform.position, Quaternion.identity);

        if (m_Target)
        {
            gameObject.transform.rotation = Quaternion.Slerp(
                gameObject.transform.rotation,
            Quaternion.LookRotation(
            (m_Target.transform.position+new Vector3(0.0f,0.2f,0.0f)) - this.gameObject.transform.position),
                0.1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //プレイヤーのレベルスクリプトを取得
            GameObject m_PlayerObj = GameObject.Find("Player");
            LevelUp m_PlayerLevel = m_PlayerObj.GetComponent<LevelUp>();

            //プレイヤーの年齢 - 殺したNPCの年齢
            int npcAge = collision.gameObject.GetComponent<NpcAgeManage>().m_Age;
            m_PlayerLevel.m_Age -= npcAge;

            Destroy(collision.gameObject);
        }
    }

    public ref GameObject GetTargetObject()
    {
        return ref m_Target;
    }
}
