using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    public float moveDuration = 3f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        // Di chuyển từ vị trí A đến vị trí B trong moveDuration giây
        float elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, pointB.position, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Di chuyển từ vị trí B đến vị trí C trong moveDuration giây
        elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(pointB.position, pointC.position, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        //yield return new WaitForSeconds(0.5f);


        // Di chuyển từ vị trí C về vị trí B trong moveDuration giây
        elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(pointC.position, pointB.position, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Di chuyển từ vị trí B đến vị trí D trong moveDuration giây
        elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(pointB.position, pointD.position, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Xóa vật thể
        Destroy(gameObject);
    }
}
