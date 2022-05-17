using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMove : MonoBehaviour
{
    [Header("�ړ���̏ꏊ�������I�u�W�F�N�g")]
    public GameObject AfterPoint;

    [Header("�ړ����鎞��(�b)")]
    public float MoveTime;

    public GameObject m_FPS_ControlObject;
    //�ړ��x�N�g��
    private Vector3 afterPosVec;

    // Start is called before the first frame update
    void Start()
    {
        ref var SystemFrameRate= ref m_FPS_ControlObject.gameObject.GetComponent<FrameRate_Control>().SetFrameRate;

        afterPosVec = AfterPoint.gameObject.transform.position - this.gameObject.transform.position;
        afterPosVec /= MoveTime* SystemFrameRate;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += afterPosVec;

        if (AfterPoint.gameObject.transform.position.y< this.gameObject.transform.position.y)
        {
            //��A�N�e�B�u��
            this.enabled = false;

        }
    }
}
