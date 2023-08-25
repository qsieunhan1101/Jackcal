using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleChecker : MonoBehaviour
{
    private PlayerMoment player;
    [SerializeField] private float angle;
    [SerializeField] private Vector2 A, B, C;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerMoment>();
    }


    public float CheckAngle()
    {
        A = new Vector2(transform.position.x, transform.position.y);
        B = new Vector2(player.transform.position.x,player.transform.position.y);
        C = B - A;

        angle = Mathf.Atan2(C.x,C.y) * Mathf.Rad2Deg;
        angle = Mathf.Round(angle/45) * 45;

        return angle;
    }
}
