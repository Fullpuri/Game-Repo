using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaderActivate : MonoBehaviour
{
    [Header("レーダー用のカメラ")]
    public GameObject m_Rader;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (m_Rader.gameObject.activeInHierarchy)
            {
                m_Rader.gameObject.SetActive(false);

            }
            else
            {
                m_Rader.gameObject.SetActive(true);
            }
        }
    }
}
