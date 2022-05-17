using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCamRotate : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    public float speed;

    void Update()
    {
        //RotateAround(���S�̏ꏊ,��,��]�p�x)
        transform.RotateAround(
            target.transform.position,
            Vector3.up,
            speed * Time.deltaTime
            );
    }
}
