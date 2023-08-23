using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position- transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
        //Destroy(this.gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
