using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public GameObject helicopter;
    public Animator anim;
    public float speed = 5f;
    public Vector3 targetPosition = new Vector3(-3.56f, 42.98f,0f);

    [SerializeField] private bool isTrigger = false;

    private void Start()
    {
    }

    private void Update()
    {
        if (isTrigger)
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        helicopter.SetActive(true);
        if (helicopter.transform.position != targetPosition)
        {
            helicopter.transform.position = Vector2.MoveTowards(helicopter.transform.position, targetPosition, Time.deltaTime * speed);
            anim.SetBool("Fly", true);
        }
        if(helicopter.transform.position == targetPosition)
        {
            anim.SetBool("Fly", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isTrigger = true;
        }
    }
}
