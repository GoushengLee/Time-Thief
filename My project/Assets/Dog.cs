using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Dog : MonoBehaviour
{
    public float speed = 5f; 
    public string state;
    public Transform stopP0, stopP1;
    float timer = 3;
    public bool movRight = false;

    void Start()
    {
        state = "Running";
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (state == "Running")
                state = "Frozen";
        }
        if (collision.gameObject.tag == "Player")
        {
            if (state == "Running") { SceneManager.LoadScene("Gameover"); }
                
        }
    }
    void Update()
    {

        if (state == "Running")
        {

            if (movRight == false) { this.transform.position = Vector2.MoveTowards(this.transform.position, stopP0.position, speed * Time.deltaTime); }
            if (movRight == true) { this.transform.position = Vector2.MoveTowards(this.transform.position, stopP1.position, speed * Time.deltaTime); }
            if (this.transform.position.x == stopP0.transform.position.x) { movRight = !movRight; }
            if (this.transform.position.x == stopP1.transform.position.x) { movRight = !movRight; }
        }
        if (state == "Frozen")
        {
            timer -= Time.deltaTime;

            Debug.Log("Freeze");
            if (timer <= 0)
            {
                state = "Running";
                timer = 3;
            }
        }

    }
}
