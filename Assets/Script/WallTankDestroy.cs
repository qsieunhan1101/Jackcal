using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTankDestroy : MonoBehaviour
{
    
    public GameObject tankChild;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("Grenade"))
        {
            tankChild.GetComponent<Animator>().SetTrigger("Destroy");

            Destroy(gameObject, 0.7f);
        }
    }
}
