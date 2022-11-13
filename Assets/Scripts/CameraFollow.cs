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
    public bool lookAtTarget = false;
    void Start()
    {
        initialOffset = transform.position - targetObject.position;
        //initialOffsetRotation = transform.rotation - targetObject.rotation;
    }

    private void LateUpdate()
    {
        cameraPosition = targetObject.position + initialOffset;
        transform.position = cameraPosition;

       // transform.rotation = Quaternion.Euler(targetObject.eulerAngles.x+26f, targetObject.eulerAngles.y -180, targetObject.eulerAngles.z);
        //if(lookAtTarget)
        //{
        //    transform.LookAt(targetObject);
        //}
    }
}
