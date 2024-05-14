using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoushengMoveInput : MonoBehaviour
{
    public float moveSpeed = 5f; // 角色移动速度
    public float smoothMovementTime = 0.3f; // 移动平滑的时间
    public float jumpForce = 10f; // 跳跃力量
    public bool isGrounded = true; // 检查角色是否在地面上
    private Rigidbody2D rb;
    public Vector2 currentVelocity; // 当前速度，用于平滑移动的计算
    public Vector2 targetVelocity; // 目标速度
    public bool iswalk;
    public SpriteRenderer playerSprite;

    public string FaceDir; //which side player is facing, Left or Right

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 获取 Rigidbody2D 组件
        playerSprite = rb.GetComponent<SpriteRenderer>();
        FaceDir = "Right";

    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        // 获取水平输入（A/D键或左右箭头键）

        // 设置目标速度
        targetVelocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // 检测是否按下跳跃键并且角色在地面上
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // 使角色跳跃
            isGrounded = false; // 角色已经跳跃，不再在地面上
        }
        if (horizontalInput > 0) // 向右移动
        {
            FaceDir = "Right";

        }
        else if (horizontalInput < 0) // 向左移动
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
        // 使用线性插值平滑地调整速度
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref currentVelocity, smoothMovementTime);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 确保与地面接触
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
