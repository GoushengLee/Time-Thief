using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject hand; // 手的游戏对象
    public Transform reachTarget; // 手伸出的目标位置
    public float speed = 10f; // 手伸出的速度
    public  Transform originalPosition; // 手的原始位置
    private bool isReaching = false; // 是否正在伸出手

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isReaching = !isReaching; // 切换伸出状态
        }

        if (isReaching)
        {
            // 伸出手
            hand.transform.position = Vector3.MoveTowards(hand.transform.position, reachTarget.position, speed * Time.deltaTime);
        }
        if (hand.transform.position == reachTarget.position) { isReaching = !isReaching; }
        if (!isReaching)
        {
            // 回收手
            hand.transform.position = Vector3.MoveTowards(hand.transform.position, originalPosition.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("breakable"))
        {
            Destroy(other.gameObject); // 破坏特殊方块
        }
    }
}
