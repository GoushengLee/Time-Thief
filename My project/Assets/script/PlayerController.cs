using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, yinput,xinput,yspeed;
    public int HP;
    Rigidbody2D Player;
    public GameManager GM;
    private void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        speed = 10;
        yspeed = 4;
        HP = 4;
    }


    private void Update()
    {
        xinput = Input.GetAxis("Horizontal") * speed;
        if (Input.GetKeyDown(KeyCode.Space))
            {
            Player.velocity = Vector2.up * yspeed;
            }
 
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        /* 游戏结束时停止运动
        if (GM.Gameover == false)
        {
        */
        Player.velocity = new Vector2(xinput, Player.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Scence2 扣血
        /*
        if (collision.tag == "Boss")
        {
            HP -= 1;
        }
        */
    }
   

}
