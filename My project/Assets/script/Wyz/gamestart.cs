using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamestart : MonoBehaviour
{

    public int sceneIndex,nowscence;
    public flag flag;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = 2;
        if (flag != null)
        { 
        nowscence = flag.GameLevel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        // 加载指定序号的场景
        if (CompareTag("jump"))
        {
            SceneManager.LoadScene(nowscence +1);
        }
        if (CompareTag("quit"))
        {
            Application.Quit();
        }
        if (CompareTag("restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
