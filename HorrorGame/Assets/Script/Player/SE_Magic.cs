using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Magic : MonoBehaviour
{
    [SerializeField] private AudioSource MagicShotSESource = null;

    // Start is called before the first frame update
    void Start()
    {
        MagicShotSESource = this.gameObject.GetComponent<AudioSource>();

        MagicShotSESource.PlayOneShot(MagicShotSESource.clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
