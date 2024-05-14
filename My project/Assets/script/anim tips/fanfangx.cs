using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanfangx : MonoBehaviour
{
    public Rigidbody2D rb; // Rigidbody 组件，用于给物体施加力
    public float flyOutSpeed;// 飞出的速度
    public float coolDown= 0;
    public bool canfire;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        coolDown -= Time.deltaTime;
        if (coolDown < 0) { coolDown = 0; }
        if (Input.GetMouseButtonDown(1)&&coolDown <=0)
        {
            canfire = true;
            // 获取鼠标点击位置，并将其转换为世界坐标
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f; // 设置一个距离摄像机的距离，使其在摄像机的视野内
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // 计算飞出的方向（物体当前位置指向鼠标点击位置的反方向）
            Vector3 direction = transform.position - targetPosition;

            // 施加力使物体飞出
            rb.AddForce(direction.normalized * flyOutSpeed);
            coolDown = 1f;
        }
        if (coolDown > 0)
        {
            canfire = false;
        }
    }
}
