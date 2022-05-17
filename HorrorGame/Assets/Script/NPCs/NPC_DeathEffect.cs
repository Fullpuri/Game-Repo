using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_DeathEffect : MonoBehaviour
{
    [Header("���S�G�t�F�N�g��������܂ł̎���")]
    public float DestoryTime = 1.0f;

    public AudioSource DeathSoundEffect=null;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, DestoryTime);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
