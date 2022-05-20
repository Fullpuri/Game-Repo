using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaderActivate : MonoBehaviour
{
    [Header("���[�_�[�p�̃J����")]
    public GameObject m_Rader;

    [Header("�v���C���[�̃��x���Ǘ��X�N���v�g")]
    private LevelUp m_PlayerLevel = null;


    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̃��x���X�N���v�g���擾
        GameObject m_PlayerObj = GameObject.Find("Player");
        m_PlayerLevel = m_PlayerObj.GetComponent<LevelUp>();

        m_Rader.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //RaderActivate�R���|�[�l���g�̂ݍ폜����
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
