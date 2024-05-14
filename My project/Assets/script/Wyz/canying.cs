using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canying : MonoBehaviour
{

    public GameObject originalObject; // ԭʼ����
    public GameObject ghostPrefab; // ��Ӱ�����Ԥ����
    public float ghostSpawnInterval = 0.1f; // ��Ӱ���ɼ��
    public float ghostFadeDuration = 1f; // ��Ӱ����ʱ��

    private float lastSpawnTime;

    void Start()
    {
        lastSpawnTime = Time.time;
    }

    void Update()
    {
        // ����Ƿ���Ҫ���ɲ�Ӱ
        if (Time.time - lastSpawnTime > ghostSpawnInterval)
        {
            // ���ɲ�Ӱ
            GameObject ghost = Instantiate(ghostPrefab, originalObject.transform.position, originalObject.transform.rotation);
            // ������Ӱ����ȣ�ʹ����ԭʼ�������
            ghost.transform.position -= originalObject.transform.forward * 0.1f;
            // ���ò�Ӱ��͸����Ϊ1
            SetGhostOpacity(ghost, 1f);
            // �����������ʱ��
            lastSpawnTime = Time.time;
            // ���ٲ�Ӱ
            Destroy(ghost, ghostFadeDuration);
        }
    }

    // ���ò�Ӱ��͸����
    private void SetGhostOpacity(GameObject ghost, float opacity)
    {
        SpriteRenderer ghostRenderer = ghost.GetComponent<SpriteRenderer>();
        Color ghostColor = ghostRenderer.color;
        ghostColor.a = opacity;
        ghostRenderer.color = ghostColor;
    }
}


