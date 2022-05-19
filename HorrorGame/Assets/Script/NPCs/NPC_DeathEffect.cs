using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_DeathEffect : MonoBehaviour
{
    [Header("���S�G�t�F�N�g��������܂ł̎���")]
    public float DestoryTime = 1.0f;

    [Header("���S���̃T�E���h�G�t�F�N�g")]
    [SerializeField] private AudioSource DeathSESource=null;
    private AudioClip DeathSEClip = null;

    // Start is called before the first frame update
    void Start()
    {
        //���g��AudioSource�R���|�[�l���g���Q��
        DeathSESource = this.gameObject.GetComponent<AudioSource>();
        DeathSEClip = DeathSESource.clip;
        DeathSESource.PlayOneShot(DeathSEClip);

        //���g�̔j�����n�߂�
        Destroy(this.gameObject, DestoryTime);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
