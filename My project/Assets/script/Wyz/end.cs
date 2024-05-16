using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    public flag glag;
    // Start is called before the first frame update
    void Start()
    {
        glag = GetComponent<flag>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && glag.open == true)
        {
            SceneManager.LoadScene("Credit");
        }
    }
}
