using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5f; // ��ɫ�ƶ��ٶ�
    public float smoothMovementTime = 0.3f; // �ƶ�ƽ����ʱ��
    public float jumpForce = 10f; // ��Ծ����
    private bool isGrounded = true; // ����ɫ�Ƿ��ڵ�����
    private Rigidbody2D rb;
    private Vector2 currentVelocity; // ��ǰ�ٶȣ�����ƽ���ƶ��ļ���
    private Vector2 targetVelocity; // Ŀ���ٶ�
    public Animator PlayAnimation; // �������ҵĶ���
    public GameObject mouse;
    Vector3 mousepos;

    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>(); // ��ȡ Rigidbody2D ���
    }

    void Update()
    {
      
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // ����Ŀ���ٶ�
        targetVelocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // ����Ƿ�����Ծ�����ҽ�ɫ�ڵ�����
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // ʹ��ɫ��Ծ
            isGrounded = false; // ��ɫ�Ѿ���Ծ�������ڵ�����
        }
        if (horizontalInput > 0) // �����ƶ�
        {
            // transform.localScale = new Vector3(1, 1, 1); // �����ұ�
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalInput < 0) // �����ƶ�
        {
            //transform.localScale = new Vector3(-1, 1, 1); // �������
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
    }

    void FixedUpdate()
    {
        // ʹ�����Բ�ֵƽ���ص����ٶ�
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref currentVelocity, smoothMovementTime);
    }
    void hit()
    {
        mousepos = mouse.transform.position;  
    }
}
