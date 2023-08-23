using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;

    private Vector2 getPlayerPos;

    public float rangeSphere;

    float distanceFromShoot;

    GameObject Player;

    Vector3 playerGetPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerGetPos = GameObject.Find("Player").transform.position;

        Player = GameObject.Find("Player");
        rangeSphere = Player.GetComponent<Weapon>().destroyRadius;
     
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromShoot = Vector3.Distance(playerGetPos, transform.position);

        if (distanceFromShoot >= rangeSphere)
        {
            StartCoroutine(CollideOpject());
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WallTank"))
        {
            StartCoroutine(CollideOpject());

        }
    }

    private IEnumerator CollideOpject ()
    {
        animator.SetTrigger("Explode");
        yield return new WaitForSeconds(0.02f);
        rb.bodyType = RigidbodyType2D.Static;
        Destroy(gameObject,0.7f);
    }

}
