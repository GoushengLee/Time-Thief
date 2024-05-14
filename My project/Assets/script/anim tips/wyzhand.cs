using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wyzhand : MonoBehaviour
{
    public GameObject hand, maincamera,player;
    public float topAngleR, BottomAngleR, topAngleL, BottomAngleL;// 限制枪口可转动的角度
    Vector2 mouseposition;//获取鼠标位置
    public float angle;//计算鼠标角度
    public string overangle;
    public GameManager GM;
    public SpriteRenderer HandSprite;
    Vector2 direction;
    public GoushengMoveInput PlayerScript;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GM").GetComponent<GameManager>();
        maincamera = GameObject.FindGameObjectWithTag("MainCamera");

    }

    // Update is called once per frame
    void Update()
    {
        if (GM.GameState == "GameOn")
        {

            mouseposition = maincamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            direction = new Vector2(mouseposition.x - transform.position.x, mouseposition.y - transform.position.y);
            angle = Vector2.Angle(direction, Vector2.right);

            // if mouse on right side
            if (mouseposition.x > player.transform.position.x)
            {
                player.GetComponent<SpriteRenderer>().flipX = false;
                HandSprite.flipY = false;
                player.GetComponent<SpriteRenderer>().flipX = false;
                hand.transform.right = direction; //follow mouse pos

            }
            // if mouse on left side
            if (mouseposition.x < player.transform.position.x)
            {
                player.GetComponent<SpriteRenderer>().flipX = true;

                HandSprite.flipY = true;
                player.GetComponent<SpriteRenderer>().flipX = true;
                hand.transform.right = direction; //follow mouse pos

            }

        }
            
    }
}
