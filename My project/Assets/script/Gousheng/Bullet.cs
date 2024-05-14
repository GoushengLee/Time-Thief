using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifespan = 1f; // ×Óµ¯´æÔÚµÄÊ±¼ä³¤¶È

    void Start()
    {
        Destroy(gameObject, lifespan); // 2Ãëºó×Ô¶¯Ïú»Ù×Óµ¯
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // µ±×Óµ¯ÓëÈÎºÎÎïÌåÅö×²Ê±Ïú»Ù×Óµ¯
        if (collision.gameObject.tag == "Ground" && collision.gameObject.tag == "moveground")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Untagged")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "moveground")
        {
            Destroy(this.gameObject);
        }
    }
}
