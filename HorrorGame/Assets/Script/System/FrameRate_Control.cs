using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate_Control : MonoBehaviour
{
    [Header("1�b�Ԃ̃t���[����")]
    public int SetFrameRate;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = SetFrameRate;

        //�t���[�����[�g���擾��������ʂ����X����̂�
        //�j�����Ȃ��ق����ǂ�
        //Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
