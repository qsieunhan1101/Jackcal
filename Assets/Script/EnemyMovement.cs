using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform target;
    [SerializeField] private float enemyActiveZone = 10f;
    private int index = 7;
    private Vector3[] targetTranform;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        targetTranform = new Vector3[8];
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(target.position, transform.position);
        if (distance < enemyActiveZone)
        {
            Vector3 dir = target.position - transform.position;
            if (dir != Vector3.zero)
            {
                anim.SetFloat("x", dir.x);
                anim.SetFloat("y", dir.y);
            }
            EnemyMove();
        }

    }

    private void EnemyMove()
    {
        GetTranformMove();
        if (transform.position != targetTranform[index])
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTranform[index], moveSpeed * Time.deltaTime);
        }

        if (transform.position == targetTranform[index])
        {
            index += 1;
        }

    }

    private void GetTranformMove()
    {
        if (index == 7)
        {
            index = 0;
            targetTranform[0] = new Vector3(target.transform.position.x, target.transform.position.y + 2f);
        }
        if (index == 0)
        {
            targetTranform[1] = new Vector3(target.transform.position.x + 1.5f, target.transform.position.y + 1.5f);
        }
        if (index == 1)
        {
            targetTranform[2] = new Vector3(target.transform.position.x + 2f, target.transform.position.y);
        }
        if (index == 2)
        {
            targetTranform[3] = new Vector3(target.transform.position.x + 1.5f, target.transform.position.y - 1.5f);
        }
        if (index == 3)
        {
            targetTranform[4] = new Vector3(target.transform.position.x, target.transform.position.y - 2f);
        }
        if (index == 4)
        {
            targetTranform[5] = new Vector3(target.transform.position.x - 1.5f, target.transform.position.y - 1.5f);
        }
        if (index == 5)
        {
            targetTranform[6] = new Vector3(target.transform.position.x - 2f, target.transform.position.y);
        }
        if (index == 6)
        {
            targetTranform[7] = new Vector3(target.transform.position.x - 1.5f, target.transform.position.y + 1.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grenade") || collision.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
        }
    }
}
