using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate_Control : MonoBehaviour
{
    [Header("1秒間のフレーム数")]
    public int SetFrameRate;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = SetFrameRate;

        //フレームレートを取得したい場面が多々あるので
        //破棄しないほうが良い
        //Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
