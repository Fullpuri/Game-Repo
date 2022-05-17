using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityColisionEnable : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //メッシュコライダーのアクティブ状態の切り替え
        var MeshCol = GetComponent<MeshCollider>();

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (MeshCol.enabled)
            {
                MeshCol.enabled = false;
            }
            else
            {
                MeshCol.enabled = true;
            }
        }
    }
}
