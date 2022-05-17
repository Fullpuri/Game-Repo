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
        //���b�V���R���C�_�[�̃A�N�e�B�u��Ԃ̐؂�ւ�
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
