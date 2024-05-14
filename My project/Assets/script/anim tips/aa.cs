using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aa : MonoBehaviour
{
    public GameObject Bullet, stopitem;
    private Transform m_transform;
    public int stoptime;
    public bool stop;

    // Start is called before the first frame update
    Camera cam;
    void Start()
    {
        cam = Camera.main;
        m_transform = transform;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 weaponDir = mousePos - m_transform.position;
        weaponDir.z = 0;
        weaponDir.Normalize(); // ≥§∂»πÈ“ª
        m_transform.right = weaponDir;
        //float zAngle = Mathf.Atan2(weaponDir.y, weaponDir.x) * Mathf.Rad2Deg;
        //m_transform.localEulerAngles=new Vector3(0,0,zAngle);
        if (Input.GetMouseButtonDown(0))
        {
            //GameObject fireFX = Instantiate(FireFX);
            //fireFX.transform.position= m_transform.position;
            //Destroy( fireFX ,2f);
            Bullet.transform.position = m_transform.position;
            Bullet.transform.right = m_transform.right;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            stop = true;
            stoptime--;
            if(stoptime <=0)
            { 

            }
        }
    }


}
