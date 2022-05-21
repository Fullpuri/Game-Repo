using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [Header("移動速度")]
    public float m_speed = 0.1f;
    [Header("ダッシュ速度")]
    public float m_dashSpeed;
    [Header("カメラオブジェクト")]
    public GameObject m_camObj;
    [Header("重力")]
    public Rigidbody m_rigidbody; 
    [Header("カメラの感度")]
    public float m_sensityvityX = 3.0f, m_sensityvityY = 3.0f;
    [Header("カメラの角度制限用")]
    public float m_minX = -90.0f, m_maxX = 90.0f;
    [Header("落下対策")]
    public float m_fallPos = -3.0f;

    //カメラとキャラの回転値
    public Quaternion m_camRot, m_charaRot;

    float m_moveX, m_moveZ;

    bool m_cursorLock = true;

    // Start is called before the first frame update
    void Start()
    {
        m_camRot = Quaternion.Euler(0, 0, 0);
        //m_camRot = m_camObj.transform.localRotation;
        m_charaRot = transform.localRotation;

        m_rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * m_sensityvityY;
        float yRot = Input.GetAxis("Mouse Y") * m_sensityvityX;

        m_camRot *= Quaternion.Euler(-yRot, 0, 0);
        m_charaRot *= Quaternion.Euler(0, xRot, 0);

        //Updateの中で作成した関数を呼ぶ
        m_camRot = ClampRotation(m_camRot);

        m_camObj.transform.localRotation = m_camRot;
        transform.localRotation = m_charaRot;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            m_camRot = Quaternion.Euler(0, 0, 0);
        }

        //マウスカーソルを画面の中央に固定
        UpdateCursorLock();

        //プレイヤーのy座標がある一定のラインを超えると
        //道路の真ん中にワープ（落下対策）
        if (this.transform.position.y < m_fallPos)
        {
            this.transform.position = new Vector3(-8.4f, 0.65f, -18.3f);
        }

   
    }

    private void FixedUpdate()
    {
        m_moveX = 0.0f;
        m_moveZ = 0.0f;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_dashSpeed = 2.0f;
        }
        else
        {
            m_dashSpeed = 1.0f;
        }

        m_moveX = Input.GetAxis("Horizontal") * m_speed * m_dashSpeed;
        m_moveZ = Input.GetAxis("Vertical") * m_speed * m_dashSpeed;

        transform.position +=
            m_camObj.transform.forward * m_moveZ +
            m_camObj.transform.right * m_moveX;
    }

    public void UpdateCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_cursorLock = false;
        }
        else if (Input.GetMouseButton(0))
        {
            m_cursorLock = true;
        }

        if (m_cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (!m_cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public Quaternion ClampRotation(Quaternion q)
    {
        //q = x,y,z,w (x,y,zはベクトル（量と向き）
        //wはスカラー（座標とは無関係の量）)

        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX, m_minX, m_maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //Debug.Log("当っています");
        }
    }
}