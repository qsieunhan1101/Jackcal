using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.1f;
    public Vector2 maxPos;
    public Vector2 minPos;
    private void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z) ;
        desiredPosition.x = Mathf.Clamp(desiredPosition.x,minPos.x,maxPos.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y,minPos.y,maxPos.y);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);    
    }
}
