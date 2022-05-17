using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*負荷テスト用
*/

public class LoadTest : MonoBehaviour
{
    const int LoadMax = 100000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < LoadMax; i++)
        {
            if (i % 2 == 0)
            {
                var a = i;
            }
        }
    }
}
