using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeUp : MonoBehaviour
{
    [Header("タイマーを描画するTMP")]
    public TextMeshProUGUI TimerText;

    [SerializeField] private GameObject m_GameOverImage=null;

    private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();


    // Start is called before the first frame update
    void Start()
    {
        m_GameOverImage.SetActive(false);

        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        var Seconds = stopwatch.Elapsed.Seconds;
        var minutes=stopwatch.Elapsed.Minutes;

        TimerText.text = string.Format("3:00/{0:0}:{1:00}", minutes, Seconds);

        //タイムオーバーしてるか確認
        TimeOverCheck();
    }

    private void TimeOverCheck()
    {
        //3分を超えているなら
        if (stopwatch.Elapsed.Minutes  >= 3)
        {
            stopwatch.Stop();
            stopwatch.Reset();
            m_GameOverImage.SetActive(true);
            //シーン遷移
            Invoke("ChangeScene", 3.0f);
        }
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene("GameStart");
    }
}
