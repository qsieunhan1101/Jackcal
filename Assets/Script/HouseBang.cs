using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBang : MonoBehaviour
{
    public SpriteRenderer House;
    public Animator houseAnimation;
    public float delayTime;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grenade"))
        {
            House.enabled = true;

            StartCoroutine(PlayAnim());
        }
    }

    private IEnumerator PlayAnim()
    {
        houseAnimation.Play("House_Destroy");
        yield return new WaitForSeconds(delayTime);
        houseAnimation.Play("House_Invisible");
    }
}
