using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5f; // 角色移动速度
    public float smoothMovementTime = 0.3f; // 移动平滑的时间
    public float jumpForce = 10f; // 跳跃力量
    private bool isGrounded = true; // 检查角色是否在地面上
    private Rigidbody2D rb;
    private Vector2 currentVelocity; // 当前速度，用于平滑移动的计算
    private Vector2 targetVelocity; // 目标速度
    public Animator PlayAnimation; // 这个是玩家的动画
    public GameObject mouse;
    Vector3 mousepos;

    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>(); // 获取 Rigidbody2D 组件
    }

    void Update()
    {
      
        float horizontalInput = Input.GetAxisRaw("Horizontal");

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
            // transform.localScale = new Vector3(1, 1, 1); // 面向右边
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalInput < 0) // 向左移动
        {
            //transform.localScale = new Vector3(-1, 1, 1); // 面向左边
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
    }

    void FixedUpdate()
    {
        // 使用线性插值平滑地调整速度
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref currentVelocity, smoothMovementTime);
    }
    void hit()
    {
        mousepos = mouse.transform.position;  
    }
}
