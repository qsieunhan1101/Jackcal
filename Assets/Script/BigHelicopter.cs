using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BigHelicopter : MonoBehaviour
{

    public Transform bigHelicopter;
    public Transform targetPosition1;
    public Transform targetPosition2;
    public float speed;

    public bool isTarget1 = false;
    public bool isTarget2 = false;

    [SerializeField] private float getTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HeliMove());

    }

    // Update is called once per frame
    void Update()
    {
        getTime = Time.deltaTime;
    }

    private void MoveToTarget1()
    {
        if (bigHelicopter.position != targetPosition1.position )
        {
            bigHelicopter.position = Vector2.MoveTowards(bigHelicopter.position, targetPosition1.position, Time.deltaTime * speed);
        }
        if (bigHelicopter.position == targetPosition1.position)
        {
            isTarget1 = true;
            speed = 1f;
        }

        if (isTarget1)
        {
            bigHelicopter.position = Vector2.MoveTowards(bigHelicopter.position, targetPosition2.position, Time.deltaTime * speed);
            if (bigHelicopter.position == targetPosition2.position)
            {
                isTarget2 = true;
                isTarget1 = false;
            }
        }

        

        if (isTarget2)
        {
            StartCoroutine(MovetoTarget2(2f));
        }
        
    }

    private IEnumerator MovetoTarget2(float delay)
    {
        yield return new WaitForSeconds(delay);
        bigHelicopter.position = Vector2.MoveTowards(bigHelicopter.position, targetPosition1.position, Time.deltaTime * speed);
        if(bigHelicopter.position == targetPosition1.position)
        {
            speed = 2f;
            bigHelicopter.position = Vector2.MoveTowards(bigHelicopter.position, Vector3.up * 5f, Time.deltaTime * speed);
        }
    }



    private IEnumerator HeliMove()
    {
        while (bigHelicopter.position != targetPosition1.position)
        {
            bigHelicopter.position = Vector2.MoveTowards(bigHelicopter.position, targetPosition1.position, Time.deltaTime * speed);
            if (bigHelicopter.position == targetPosition1.position)
            {
                isTarget1 = true;
            }
        }

        while (bigHelicopter.position != targetPosition2.position)
        {
            bigHelicopter.position = Vector2.MoveTowards(bigHelicopter.position, targetPosition2.position, Time.deltaTime * speed);
            if( bigHelicopter.position == targetPosition2.position)
            {
                isTarget2 = true;
            }
            yield return new WaitForSeconds(2f);

        }




        //bigHelicopter.position = Vector2.MoveTowards(bigHelicopter.position, targetPosition1.position, Time.deltaTime * speed);
        //yield return new WaitForSeconds(3.5f);
        //bigHelicopter.position = Vector2.MoveTowards(bigHelicopter.position, targetPosition2.position, Time.deltaTime * speed);

    }
}
