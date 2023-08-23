using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class udev : MonoBehaviour
{
    //private PlayerMoment player;
    // Start is called before the first frame update
    void Start()
    {
        //player = FindAnyObjectByType<PlayerMoment>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateFollow();
    }

    void RotateFollow()
    {
        //Vector3 playerPos = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        Vector3 dir = mousePos - transform.position;
        dir.Normalize();

        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        //angle = Mathf.Round(angle / 30) * 30;
        transform.rotation = Quaternion.Euler(0f,0f,angle*-1);
    }
}
