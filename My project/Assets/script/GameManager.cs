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
   
    // Start is called before the first frame update




    void Start()
    {
        // Ëø¶¨60Ö¡
        Application.targetFrameRate = 60;
        Setting = true;
        GameState = "GameOn";
        Level = 0;
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

            SceneManager.LoadScene("Gameover");
          
        }
       
        
        
    }
 
}
