using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleShipTrigger : MonoBehaviour
{
    public Transform battleShip;
    public Transform targetPosition;
    public float speed;

    [SerializeField] private bool isTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger)
        {
            MoveToTarget();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isTrigger = true;
        }
    }

    private void MoveToTarget()
    {
        if (battleShip.position != targetPosition.position)
        {
            battleShip.position = Vector2.MoveTowards(battleShip.position, targetPosition.position, Time.deltaTime * speed);
        }
        if (battleShip.position == targetPosition.position)
        {
        }
    }
}
