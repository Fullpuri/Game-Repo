using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_DeathEffect : MonoBehaviour
{
    [Header("死亡エフェクトが消えるまでの時間")]
    public float DestoryTime = 1.0f;

    [Header("死亡時のサウンドエフェクト")]
    [SerializeField] private AudioSource DeathSESource=null;
    private AudioClip DeathSEClip = null;

    // Start is called before the first frame update
    void Start()
    {
        //自身のAudioSourceコンポーネントを参照
        DeathSESource = this.gameObject.GetComponent<AudioSource>();
        DeathSEClip = DeathSESource.clip;
        DeathSESource.PlayOneShot(DeathSEClip);

        //自身の破棄を始める
        Destroy(this.gameObject, DestoryTime);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
