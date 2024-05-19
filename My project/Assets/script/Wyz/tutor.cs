using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tutor : MonoBehaviour
{
    public GameObject t1,t2,t3,t4,t5;
    public int gamelevel;
    bool one;
    // Start is called before the first frame update
    void Start()
    {
        one = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamelevel == 1)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                t1.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                t2.SetActive(false);
            }
            if (Input.GetMouseButtonDown(1))
            {
                t3.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                t4.SetActive(false);
            }
            if (Input.GetMouseButtonDown(0))
            {
                t5.gameObject.SetActive(false);
            }
        }
        if (gamelevel == 2)
        {
            if (Input.GetMouseButtonDown(1)||Input.GetMouseButton(1))
            {
                if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKey(KeyCode.Space))
                { 
                t1.SetActive(false);
                }
            }
        }
        
            
    }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (t5 != null&&one == false)
            {
                
            if (other.CompareTag("Player"))
            {
                t5.SetActive(true);
                one = true;
            }
            }
        }
}
