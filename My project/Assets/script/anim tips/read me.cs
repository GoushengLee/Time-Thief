using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class readme : MonoBehaviour
{
    // 本代码没有独立运行能力，只是标记一下动画的开关，方便后续修改或添加

    public Animator PlayAnimation; // 这个是玩家的动画
    public Animator handAnimation;//这个是手的动画
    private bool isGrounded = true; // 检查角色是否在地面上
    Rigidbody2D rb; // 这个是玩家的刚体
     void Start()
    {
        PlayAnimation = GetComponent<Animator>(); // 指定玩家动画控制组件

    }
    void Update()
    {
        
    }
    void PCanim()
    {
        if (isGrounded == false) // 如果离地的话播放跳跃动画
        {
            PlayAnimation.SetBool("jump", true); //播放跳跃动画
        }
        if (rb.velocity.x != 0 && isGrounded == true) // x轴速度不为0时，且在地面时
        {
            PlayAnimation.SetBool("walk", true); // 走动动画
        }
        else if(rb.velocity.x == 0 || isGrounded == false) // 如果速度为0或者离地
        {
            PlayAnimation.SetBool("walk", false); // 结束走动动画
        }
        if (isGrounded)
        {
            PlayAnimation.SetBool("jump", false); // 结束跳跃动画

        }
        //if (mouseposition.x > player.transform.position.x && PlayerScript.FaceDir == "Right") // and if player is facing right
        //{
        //    print("Facing RIGHT");
        //    HandSprite.flipY = false;
        //    //if limit angle?
        //     hand.transform.right = direction; //follow mouse pos
        //    //player hand follow mouse right side
        //}
        //else if (mouseposition.x < player.transform.position.x && PlayerScript.FaceDir == "Left")// if mouse on the left side and player face left //probably dun need to code this part
        //{
        //    print("Facing LEFT");
        //    HandSprite.flipY = true;
        //    //if limit angle?
        //    hand.transform.right = direction;           
        //    //player hand follow mouse left side
        //}
        //if (angle > topAngleR || angle < BottomAngleR )
        //{
        //    player.GetComponent<SpriteRenderer>().flipX = !player.GetComponent<SpriteRenderer>().flipX;
        //}

        //if (mouseposition.y < this.transform.position.y)
        //    angle = -angle;

        //if (hand.transform.rotation.y == 0)
        //{
        //    if (angle < topAngleR && angle > BottomAngleR)
        //    {
        //        print("hand following mouse");
        //        hand.transform.eulerAngles = new Vector3(0, 0, angle);
        //    }
        //}

        //if (player.GetComponent<Transform>().rotation.y == -180)
        //{
        //    if (angle < topAngleL && angle > BottomAngleL)
        //    {
        //        hand.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, angle);
        //    }
        //}
    }
}
