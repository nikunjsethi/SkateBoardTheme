using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    private Vector3 initialOffset;
    private Vector3 cameraPosition;
    private Vector3 initialOffsetRotation;
    private Vector3 cameraRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialOffset = transform.position - targetObject.position;
    }

    private void FixedUpdate()
    {
        cameraPosition = targetObject.position + initialOffset;
        transform.position = cameraPosition;
    }
}
