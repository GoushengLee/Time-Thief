using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canying : MonoBehaviour
{

    public GameObject originalObject; // 原始物体
    public GameObject ghostPrefab; // 残影物体的预制体
    public float ghostSpawnInterval = 0.1f; // 残影生成间隔
    public float ghostFadeDuration = 1f; // 残影淡出时间

    private float lastSpawnTime;

    void Start()
    {
        lastSpawnTime = Time.time;
    }

    void Update()
    {
        // 检查是否需要生成残影
        if (Time.time - lastSpawnTime > ghostSpawnInterval)
        {
            // 生成残影
            GameObject ghost = Instantiate(ghostPrefab, originalObject.transform.position, originalObject.transform.rotation);
            // 调整残影的深度，使其在原始物体后面
            ghost.transform.position -= originalObject.transform.forward * 0.1f;
            // 设置残影的透明度为1
            SetGhostOpacity(ghost, 1f);
            // 更新最后生成时间
            lastSpawnTime = Time.time;
            // 销毁残影
            Destroy(ghost, ghostFadeDuration);
        }
    }

    // 设置残影的透明度
    private void SetGhostOpacity(GameObject ghost, float opacity)
    {
        SpriteRenderer ghostRenderer = ghost.GetComponent<SpriteRenderer>();
        Color ghostColor = ghostRenderer.color;
        ghostColor.a = opacity;
        ghostRenderer.color = ghostColor;
    }
}


