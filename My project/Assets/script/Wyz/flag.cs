using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // 引入TextMeshPro命名空间
public class flag : MonoBehaviour
{
    public GameObject Player, key1, key2,key3;
    public GameManager GM;
    public bool open;
    public Sprite OpenImg, CloseImg;
    public int GameLevel, KeyNum, TotKey,targetKey;
    public GameObject UI;
    public TextMeshProUGUI textUI;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
        KeyNum = 0;
        targetKey = TotKey;
        //GameLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
      // GM.Level = GameLevel ;
        open = CanOpen();
        keysc();
        if (open == true)
        {
            GetComponent<SpriteRenderer>().sprite = OpenImg;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = CloseImg;
        }
        textUI.text = targetKey.ToString();
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
                targetKey -= 1;
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
                    targetKey -= 1;
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
                    targetKey -= 1;
                }
                key3.GetComponent<SpriteRenderer>().enabled = false;
            }

        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag== "Player" && open == true)
        {
            UI.SetActive(true);
        }
    }

    public void loadScence()
    {
      
        switch (GameLevel) // load scence
            {
                case  1:
                    SceneManager.LoadScene("level_2");
                    GameLevel = 2;
                GameManager.Instance.Level = 2;
                    break;
                case 2:
                    SceneManager.LoadScene("level_3");
                    GameLevel = 3;
                GameManager.Instance.Level = 3;
                break;
                case 3:

                    break;
            }
    }
}
