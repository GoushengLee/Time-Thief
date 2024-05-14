using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamestart : MonoBehaviour
{

    public int sceneIndex,nowscence;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = 2;

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
            SceneManager.LoadScene(sceneIndex);
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
