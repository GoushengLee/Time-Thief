using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class readme : MonoBehaviour
{
    // ������û�ж�������������ֻ�Ǳ��һ�¶����Ŀ��أ���������޸Ļ����

    public Animator PlayAnimation; // �������ҵĶ���
    public Animator handAnimation;//������ֵĶ���
    private bool isGrounded = true; // ����ɫ�Ƿ��ڵ�����
    Rigidbody2D rb; // �������ҵĸ���
     void Start()
    {
        PlayAnimation = GetComponent<Animator>(); // ָ����Ҷ����������

    }
    void Update()
    {
        
    }
    void PCanim()
    {
        if (isGrounded == false) // �����صĻ�������Ծ����
        {
            PlayAnimation.SetBool("jump", true); //������Ծ����
        }
        if (rb.velocity.x != 0 && isGrounded == true) // x���ٶȲ�Ϊ0ʱ�����ڵ���ʱ
        {
            PlayAnimation.SetBool("walk", true); // �߶�����
        }
        else if(rb.velocity.x == 0 || isGrounded == false) // ����ٶ�Ϊ0�������
        {
            PlayAnimation.SetBool("walk", false); // �����߶�����
        }
        if (isGrounded)
        {
            PlayAnimation.SetBool("jump", false); // ������Ծ����

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
