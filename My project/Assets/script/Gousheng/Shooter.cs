using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firePointR, firePointL,OpenFirePoint; // 发射子弹的起始位置
    public GameObject bulletPrefab, player; // 子弹的预制体
    public float bulletSpeed = 20f; // 子弹的速度
    public GameManager GM;
    Vector2 direction;
    Vector3 mousePosition;
    float angle;

    private void Start()
    {
        GM = GameObject.Find("GM").GetComponent<GameManager>();

    }
    void Update()
    {
        if (GM.GameState == "GameOn")// 当游戏没暂停
        {
            if (player.GetComponent<SpriteRenderer>().flipX == false)
            {
                OpenFirePoint = firePointR;
            }
            else
            {
                OpenFirePoint = firePointL;
            }

            if (Input.GetMouseButtonDown(0)) // 检测鼠标左键点击
            {
                Shoot();
            }
        }
        
    }

    void Shoot()
    {

        // 将鼠标屏幕位置转换为世界坐标
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // 计算射击方向
         direction = (mousePosition - OpenFirePoint.position).normalized;

        // 计算角度
         angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 创建子弹实例，并设置旋转以指向鼠标位置
        GameObject bullet = Instantiate(bulletPrefab, OpenFirePoint.position, Quaternion.Euler(0, 0, angle));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // 给子弹添加速度
        rb.velocity = direction * bulletSpeed;

    }
}
