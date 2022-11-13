using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    public Transform skateBoard;

    private void LateUpdate()
    {
        Vector3 newPosition = skateBoard.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        //transform.rotation = Quaternion.Euler(90f, skateBoard.eulerAngles.y, 0f);
    }
}
