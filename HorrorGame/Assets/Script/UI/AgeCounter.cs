using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgeCounter : MonoBehaviour
{
    [Header("�v���C���[�̔N��")]
    public TextMeshProUGUI m_AgeCountText=null;
    [Header("�ڍׂȏ��̕\��")]
    public TextMeshProUGUI m_AgeDetailsInfo = null;

    private int m_Age=0;

    [Header("�v���C���[�̃��x���Ǘ��X�N���v�g")]
    private LevelUp m_PlayerLevel = null;


    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̃��x���X�N���v�g���擾
        GameObject m_PlayerObj = GameObject.Find("Player");
        m_PlayerLevel = m_PlayerObj.GetComponent<LevelUp>();
    }

    // Update is called once per frame
    void Update()
    {

        m_Age = GameObject.Find("Player").GetComponent<LevelUp>().m_Age;
        m_AgeCountText.text = string.Format("{0}��", m_Age);

        switch (m_PlayerLevel.GetNowState())
        {
            case (int)Form.State.First:
                {
                    m_AgeDetailsInfo.text = string.Format(
                        "���݂̃��x��:1" +
                        "\n���݊J�����̔\��:" +
                        "\n��" +

                        "\n���ŊJ��:" +
                        "\n���̋���" +
                        "\n�ړ����x�㏸");
                    break;
                }
            case (int)Form.State.Second:
                {
                    m_AgeDetailsInfo.text = string.Format(
                        "���݂̃��x��:2" +
                        "\n���݊J�����̔\��:" +
                        "\n���̋���" +
                        "\n�ړ����x�㏸" +

                        "\n���ŊJ��:" +
                        "\n���V");
                    break;
                }
            case (int)Form.State.Third:
                {
                    m_AgeDetailsInfo.text = string.Format(
                        "���݂̃��x��:3" +
                        "\n���݊J�����̔\��:" +
                        "\n���̋���" +
                        "\n�ړ����x�㏸" +
                        "\n���V" +

                        "\n���ŊJ��:" +
                        "\n�Ǌђ�" +
                        "\n���̋��剻");
                    break;
                }
            case (int)Form.State.Fourth:
                {
                    m_AgeDetailsInfo.text = string.Format(
                        "���݂̃��x��:4" +
                        "\n���݊J�����̔\��:" +
                        "\n���̋���" +
                        "\n�ړ����x�㏸" +
                        "\n���V" +
                        "\n�Ǌђ�" +
                        "\n���̋��剻" +

                        "\n���ŊJ��:" +
                        "\n�~�j�}�b�v" +
                        "\n�G�l���M�[�e");
                    break;
                }
            case (int)Form.State.Five:
                {
                    m_AgeDetailsInfo.text = string.Format(
                        "���݂̃��x��:5" +
                        "\n���݊J�����̔\��:" +
                        "\n���̋���" +
                        "\n�ړ����x�㏸" +
                        "\n���V" +
                        "\n�Ǌђ�" +
                        "\n���̋��剻" +
                        "\n�~�j�}�b�v" +
                        "\n�G�l���M�[�e" +

                        "\n���x������ɓ��B");
                    break;
                }
        }
    }
}
