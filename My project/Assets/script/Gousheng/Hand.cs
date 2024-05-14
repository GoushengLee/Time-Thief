using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject hand; // �ֵ���Ϸ����
    public Transform reachTarget; // �������Ŀ��λ��
    public float speed = 10f; // ��������ٶ�
    public  Transform originalPosition; // �ֵ�ԭʼλ��
    private bool isReaching = false; // �Ƿ����������

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isReaching = !isReaching; // �л����״̬
        }

        if (isReaching)
        {
            // �����
            hand.transform.position = Vector3.MoveTowards(hand.transform.position, reachTarget.position, speed * Time.deltaTime);
        }
        if (hand.transform.position == reachTarget.position) { isReaching = !isReaching; }
        if (!isReaching)
        {
            // ������
            hand.transform.position = Vector3.MoveTowards(hand.transform.position, originalPosition.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("breakable"))
        {
            Destroy(other.gameObject); // �ƻ����ⷽ��
        }
    }
}
