using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;

    public int checkpos = 0;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        if (transform.position != pos1.transform.position && checkpos == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos1.transform.position, speed * Time.deltaTime);
            if (transform.position == pos1.transform.position)
            {
                checkpos = 1;
            }
        }

        if (transform.position != pos2.transform.position && checkpos == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos2.transform.position, 0.5f * Time.deltaTime);
            if (transform.position == pos2.transform.position)
            {
                checkpos = 2;
                pos1.SetActive(false);

            }
        }


        if (transform.position != pos3.transform.position && checkpos == 2)
        {
            yield return new WaitForSeconds(1f);

            transform.position = Vector2.MoveTowards(transform.position, pos3.transform.position, 0.5f * Time.deltaTime);
            if (transform.position == pos3.transform.position)
            {
                checkpos = 3;
            } 

        }

        if (transform.position != pos4.transform.position && checkpos == 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos4.transform.position, speed * Time.deltaTime);
            if(transform.position == pos4.transform.position)
            {
                Destroy(gameObject);
            }
        }
    }
}
