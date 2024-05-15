using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    public Button butn;
    public string sceneName;
    public int lastlevel;
    public flag flag;
    // Start is called before the first frame update
    void Start()
    {
        lastlevel = GameManager.Instance.Level;
        butn = GetComponent<Button>();
        if (butn!= null)
        {
            butn.onClick.AddListener(OnButtonClick);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        switch (lastlevel)
        {
            case 1:
                sceneName = ("level_1");
                break;

                case 2 :
                sceneName = ("level_2");

                break;

            case 3:
                sceneName = ("level_3");

                break;
        }
    }
    void OnButtonClick()
    {
        // 加载指定的场景
        if (this.CompareTag("restart"))
        {
        SceneManager.LoadScene(sceneName);
            
        }
        if (this.CompareTag("quit"))
        {
            Application.Quit();
        }
        if (flag != null)
        { 
        if(this.CompareTag("jump"))
        {
            flag.loadScence();
        }
        }
    }
}
