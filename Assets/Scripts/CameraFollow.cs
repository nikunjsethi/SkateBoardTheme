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
    }
}
