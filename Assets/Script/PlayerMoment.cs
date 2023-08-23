using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoment : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 moveDirection;
    public Rigidbody2D rb;
    public Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Move();
        Animation();
    }

    private void Move()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");
        if(movex == 0 && movey == 0)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }
        
        moveDirection = new Vector2(movex, movey).normalized;

        rb.velocity = moveDirection * moveSpeed * Time.deltaTime;
    }

    void Animation()
    {
        animator.SetFloat("X", moveDirection.x);
        animator.SetFloat("Y", moveDirection.y);
    }
}
