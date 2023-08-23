using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallCannon : MonoBehaviour
{
    public GameObject TankChild;

    [SerializeField] private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    public float fireRate = 1f;


    private AngleChecker angler;
    public float lineOfSite;
    public float shootingRange;
    private Transform player;


    public float delay = 0.3f;
    public float delayCounter;

    public float couterShoot = 0.1f;



    
    public int bulletsPerSalvo = 3; // Số viên đạn mỗi lần bắn
    public float salvoInterval = 2f;
    public float fireTimer = 0f; // Đếm thời gian giữa các lần bắn
    public int bulletsShot = 0;

    // Start is called before the first frame update
    void Start()
    {
        angler = GetComponent<AngleChecker>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(delayCounter <= 0)
        {
            delayCounter = delay;
            transform.rotation = Quaternion.Euler(transform.rotation.y, transform.rotation.x, angler.checkAngle() * -1);
        }
        else
        {
            delayCounter = delayCounter - Time.deltaTime;
        }

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {       
            Shoot();

        }
    }

    private void Shoot()
    {
        Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
        TankChild.GetComponent<Animator>().Play("WallTank_Shoot");
        nextFireTime = Time.time + fireRate;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
//float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
//if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
//{
//    //transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

//}
//else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
//{
//    Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
//    nextFireTime = Time.time + fireRate;
//}