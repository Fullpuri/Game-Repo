using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeUp : MonoBehaviour
{
    [Header("�^�C�}�[��`�悷��TMP")]
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

        //�^�C���I�[�o�[���Ă邩�m�F
        TimeOverCheck();
    }

    private void TimeOverCheck()
    {
        //3���𒴂��Ă���Ȃ�
        if (stopwatch.Elapsed.Minutes  >= 3)
        {
            stopwatch.Stop();
            stopwatch.Reset();
            m_GameOverImage.SetActive(true);
            //�V�[���J��
            Invoke("ChangeScene", 3.0f);
        }
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene("GameStart");
    }
}
