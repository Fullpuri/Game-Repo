using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMove : MonoBehaviour
{
    [Header("移動後の場所を示すオブジェクト")]
    public GameObject AfterPoint;

    [Header("移動する時間(秒)")]
    public float MoveTime;

    public GameObject m_FPS_ControlObject;
    //移動ベクトル
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
            //非アクティブ化
            this.enabled = false;

        }
    }
}
