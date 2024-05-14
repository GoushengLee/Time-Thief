using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplat : MonoBehaviour
{
    public Transform playerP;
    GoushengMoveInput moveInput;
    // Start is called before the first frame update
    void Start()
    {
        playerP = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("moveground"))
        {
            transform.parent = collision.transform;
            moveInput.isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("moveground"))
        {
            transform.parent = playerP;
            moveInput.isGrounded = false;

        }
    }
}