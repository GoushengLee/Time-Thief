using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firePointR, firePointL,OpenFirePoint; // �����ӵ�����ʼλ��
    public GameObject bulletPrefab, player; // �ӵ���Ԥ����
    public float bulletSpeed = 20f; // �ӵ����ٶ�
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
        if (GM.GameState == "GameOn")// ����Ϸû��ͣ
        {
            if (player.GetComponent<SpriteRenderer>().flipX == false)
            {
                OpenFirePoint = firePointR;
            }
            else
            {
                OpenFirePoint = firePointL;
            }

            if (Input.GetMouseButtonDown(0)) // ������������
            {
                Shoot();
            }
        }
        
    }

    void Shoot()
    {

        // �������Ļλ��ת��Ϊ��������
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // �����������
         direction = (mousePosition - OpenFirePoint.position).normalized;

        // ����Ƕ�
         angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // �����ӵ�ʵ������������ת��ָ�����λ��
        GameObject bullet = Instantiate(bulletPrefab, OpenFirePoint.position, Quaternion.Euler(0, 0, angle));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // ���ӵ�����ٶ�
        rb.velocity = direction * bulletSpeed;

    }
}
