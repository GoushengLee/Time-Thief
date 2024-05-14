using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoushengMoveInput : MonoBehaviour
{
    public float moveSpeed = 5f; // ��ɫ�ƶ��ٶ�
    public float smoothMovementTime = 0.3f; // �ƶ�ƽ����ʱ��
    public float jumpForce = 10f; // ��Ծ����
    public bool isGrounded = true; // ����ɫ�Ƿ��ڵ�����
    private Rigidbody2D rb;
    public Vector2 currentVelocity; // ��ǰ�ٶȣ�����ƽ���ƶ��ļ���
    public Vector2 targetVelocity; // Ŀ���ٶ�
    public bool iswalk;
    public SpriteRenderer playerSprite;

    public string FaceDir; //which side player is facing, Left or Right

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ��ȡ Rigidbody2D ���
        playerSprite = rb.GetComponent<SpriteRenderer>();
        FaceDir = "Right";

    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        // ��ȡˮƽ���루A/D�������Ҽ�ͷ����

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
            FaceDir = "Right";

        }
        else if (horizontalInput < 0) // �����ƶ�
        {
            FaceDir = "Left";
        }
        if (horizontalInput != 0)
        {
            iswalk = true;
        }
        else
        {
            iswalk = false;
        }
    }

    void FixedUpdate()
    {
        // ʹ�����Բ�ֵƽ���ص����ٶ�
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref currentVelocity, smoothMovementTime);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // ȷ�������Ӵ�
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
           isGrounded = false;
        }
    }


}
