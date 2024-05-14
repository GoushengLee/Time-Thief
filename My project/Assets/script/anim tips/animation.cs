using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class animation : MonoBehaviour
{
    public Animator PlayAnimation,openfire,baozha; // 这个是玩家的动画
    public GoushengMoveInput MoveScript; // 引用移动代码
    public GameManager GM;
    public Rigidbody2D PCrb;
    public float horizontalInput, timecount;
    public GameObject Player;
    public int CountF;
    public GameObject firepoint,firepointL,firepointR,texiao,dogA,dogB;
    bool fireOn, startcount;
    public Dog enemy, enemy2;
    public fanfangx shockgun;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GM").GetComponent<GameManager>();
        Player = GameObject.Find("player");
        PlayAnimation = GetComponent<Animator>(); // 指定玩家动画控制组件
        MoveScript = GetComponent<GoushengMoveInput>(); // 指定移动代码
        PCrb = GetComponent<Rigidbody2D>();
        horizontalInput = Input.GetAxisRaw("Horizontal");
        firepoint = gameObject.transform.GetChild(0).GetChild(0).GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.GameState == "GameOn")
        { 
        PCanim();
        fire();
            dogmov();

        }
    }
    void PCanim() // 要是修改了什么后因为动画导致bug的话可以直接整个注释掉
    {
        // 这一版是什么变量都不用改的
        if (MoveScript.isGrounded == false) // 如果离地的话播放跳跃动画
        {
            PlayAnimation.SetBool("jump", true); //播放跳跃动画
        }
        if (MoveScript.iswalk == true && MoveScript.isGrounded == true) // x轴速度不为0时，且在地面时
        {
            PlayAnimation.SetBool("walk", true); // 走动动画
        }
        else if (MoveScript.iswalk == false || MoveScript.isGrounded == false) // 如果速度为0或者离地
        {
            PlayAnimation.SetBool("walk", false); // 结束走动动画
        }
        if (MoveScript.isGrounded)
        {
            PlayAnimation.SetBool("jump", false); // 结束跳跃动画

        }
    }
    void fire()
    {
            //Animation
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                Debug.Log("on");
                fireOn = true;
                startcount = true;
            }
            //timer
            if (startcount == true)
            {
                timecount += Time.deltaTime;
            }
            if (timecount >= 0.15f)
            {
                timecount = 0;
                fireOn = false;
                startcount = false;
            }

        // player facing
        if (Player.GetComponent<SpriteRenderer>().flipX == false)
        {
            firepoint.transform.position = firepointR.transform.position;
        }
        else
        {
            firepoint.transform.position = firepointL.transform.position;
        }
        //open close animation
        if (fireOn == true)
        {
            openfire.SetBool("fire", true);
        }
        if (fireOn == false)
        {
            openfire.SetBool("fire", false);
        }
        // shockwave animation
        if (Input.GetMouseButtonDown(1) && shockgun.coolDown == 0)
        {
            texiao.gameObject.SetActive(true);
            
        }
        if (Input.GetMouseButton(1)) // holding right mouse, stop anmimation after finish
        {
            CountF++;
            if (CountF >= 16)
            {
                CountF = 0;
                texiao.gameObject.SetActive(false);
            }
        }
        if (Input.GetMouseButtonUp(1)) // stop anmimation
        {
            texiao.gameObject.SetActive(false);
        }

    }
    void dogmov()
    {
        if (dogA != null)
        {
            if (enemy.movRight == true)
            {
                dogA.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                dogA.GetComponent<SpriteRenderer>().flipX = false;

            }
            if (enemy.state == "Frozen")
            {
                dogA.GetComponent<Animator>().enabled = false;
            }
            else
            {
                dogA.GetComponent<Animator>().enabled = true;
            }
        }
        if (dogB != null)
        {
            if (enemy2.movRight == true)
            {
                dogB.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                dogB.GetComponent<SpriteRenderer>().flipX = false;

            }
            if (enemy2.state == "Frozen")
            {
                dogB.GetComponent<Animator>().enabled = false;
            }
            else
            {
                dogB.GetComponent<Animator>().enabled = true;
            }
        }
    }
}



