using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flag : MonoBehaviour
{
    public GameObject Player, key1, key2,key3;
    public GameManager GM;
    public bool open;
    public Sprite OpenImg, CloseImg;
    public int GameLevel, KeyNum, TotKey;

    // Start is called before the first frame update
    void Start()
    {
        open = false;
        KeyNum = 0;
        GameLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        GameLevel = GM.Level;
        open = CanOpen();
        if (open == true)
        {
            GetComponent<SpriteRenderer>().sprite = OpenImg;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = CloseImg;
        }
        keysc();

    }
    bool CanOpen()
    {
        if (KeyNum >= TotKey)
        {
            return true;
        }
        return false;
    }
    void keysc()
    {
        // total key number in each level
        switch (GameLevel)
        {
            case 1:
                TotKey = 1;
                break;
            case 2:
                TotKey = 1;
                break;
            case 3:
                TotKey = 3;
                break;
        }
        // got key
        if (key1.GetComponent<SpriteRenderer>().bounds.Intersects(Player.GetComponent<SpriteRenderer>().bounds))
        {
            if (key1.GetComponent<SpriteRenderer>().enabled == true)
            {
                KeyNum += 1;
            }
            key1.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (key2 != null)
        {
            if (key2.GetComponent<SpriteRenderer>().bounds.Intersects(Player.GetComponent<SpriteRenderer>().bounds))
            {
                if (key2.GetComponent<SpriteRenderer>().enabled == true)
                {
                    KeyNum += 1;
                }
                key2.GetComponent<SpriteRenderer>().enabled = false;
            }
            
        }
        if (key3 != null)
        {
            if (key3.GetComponent<SpriteRenderer>().bounds.Intersects(Player.GetComponent<SpriteRenderer>().bounds))
            {
                if (key3.GetComponent<SpriteRenderer>().enabled == true)
                {
                    KeyNum += 1;
                }
                key3.GetComponent<SpriteRenderer>().enabled = false;
            }

        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag== "Player" && open == true)
        {

         Invoke("loadScence", 3f);   
        }
    }

    void loadScence()
    { 
            switch (GameLevel) // load scence
            {
                case 1:
                    SceneManager.LoadScene(3);
                    GameLevel = 2;
                    break;
                case 2:
                    SceneManager.LoadScene("level_3");
                    GameLevel = 3;
                    break;
                case 3:

                    break;
            }
    }
}
