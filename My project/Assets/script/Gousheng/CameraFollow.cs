using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // 玩家的 Transform
    public float smoothSpeed = 0.125f; // 摄像头移动的平滑速度
    public Vector3 offset; // 摄像头相对于玩家的偏移量
    public float minX, maxX, minY, maxY; // 摄像头的移动边界

    void LateUpdate()
    {
        // 计算摄像头的目标位置
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

        // 应用边界限制
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);

        // 使用插值平滑地更新摄像头位置
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 更新摄像头的位置
        transform.position = smoothedPosition;
    }
}
