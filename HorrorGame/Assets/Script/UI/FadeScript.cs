using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public float m_fadeSpeed;
    float m_alpha;
    float m_red, m_green, m_bule;

    // Start is called before the first frame update
    void Start()
    {
        //Panel‚ÌF‚ğæ“¾
        m_red = GetComponent<Image>().color.r;
        m_green = GetComponent<Image>().color.g;
        m_bule = GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().color 
            = new Color(m_red, m_green, m_bule, m_alpha);

        m_alpha += m_fadeSpeed;
    }
}
