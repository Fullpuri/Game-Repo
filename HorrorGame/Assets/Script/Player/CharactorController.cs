using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    public float m_speed = 0.1f;
    public float m_jumpSpeed = 0.2f;
    public float m_gravity = 2.0f;
    CharacterController m_controller;
    private Vector3 m_moveDir;

    void Start()
    {
        m_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_controller.isGrounded)
        {
            m_moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            m_moveDir = transform.TransformDirection(m_moveDir) * m_speed;

            if (Input.GetButton("Jump"))
            {
                m_moveDir.y = m_jumpSpeed;
            }
        }

        m_moveDir.y -= m_gravity * Time.deltaTime;
        m_controller.Move(m_moveDir * Time.deltaTime);
    }
}
