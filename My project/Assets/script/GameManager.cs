using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player, flag;
    public bool fireOn,Setting, startcount;
    public string GameState;
    public float timecount;
    public Transform Right, Left;
    public int Level;
    public AudioSource bgmAduio;
    public Slider VolumeSlider;
    public enum PlayerState { win,lose,dead }
    public PlayerState Pstate;
    public static GameManager Instance { get; private set; }


    // Start is called before the first frame update




    void Start()
    {
        // 锁定60帧
        Application.targetFrameRate = 60;
        Setting = true;
        GameState = "GameOn";
      //  Level = 1 ;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 保持在场景切换时不被销毁
            GameManager.Instance.Level = 1;
        }

    }

    // Update is called once per frame
    private void Update()
    {
      
        if (VolumeSlider != null)
        { 
         bgmAduio.volume = VolumeSlider.value;
        }
        // gunfire animation
        // UI Open
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Open UI setting
            Setting = !Setting;
            if (Setting == true) 
            {
               GameState = "Pause";
            }
            //Close UI setting
            if (Setting == false)
            {
                GameState = "GameOn";
            }

          //  SceneManager.LoadScene("Gameover");
          
        }
    }


}
