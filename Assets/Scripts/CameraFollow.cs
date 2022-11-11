using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    private Vector3 initialOffset;
    private Vector3 cameraPosition;
    private Quaternion initialOffsetRotation;
    private Quaternion cameraRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialOffset = transform.position - targetObject.position;
        //initialOffsetRotation = Quaternion.Inverse(targetObject.rotation) * transform.rotation;
        //Debug.Log("rotation values: " + initialOffsetRotation);
    }

    private void FixedUpdate()
    {
        cameraPosition = targetObject.position + initialOffset;
        transform.position = cameraPosition;
        //transform.rotation = Quaternion.Euler(26, 90 - targetObject.transform.rotation.y, 0);
        //cameraRotation=transform.rotation*initialOffsetRotation;
        //transform.rotation = cameraRotation;
    }
}
