using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform bulletSpawnPoint;
    public float bulletSpeed;
    public GameObject grenadePrefabs;
    private Vector2 grenadeDirection;
    public float grenadeSpeed;
    public GameObject playerGetPos;

    public float destroyRadius;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(playerBullet, bulletSpawnPoint.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
        }
        grenadeDirection = GetComponent<PlayerMoment>().moveDirection;

        if (Input.GetKeyDown(KeyCode.C) && GameObject.FindWithTag("Grenade") == null)
        {
            var grenade = Instantiate(grenadePrefabs, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            grenade.GetComponent<Rigidbody2D>().velocity = grenadeDirection * grenadeSpeed;

        }
        

      
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, destroyRadius);

    }

}
