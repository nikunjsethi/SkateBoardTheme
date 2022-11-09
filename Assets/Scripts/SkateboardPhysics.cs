using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardPhysics : MonoBehaviour
{
    Rigidbody rb;
    public float jump = 2000;
    public float speed;
    public Vector3 movement;
    bool canJump;

    float hInput, vInput;
    bool isBreaking;
    float steeringAngle;

    [SerializeField] private float maxSteeringAngle;

    [SerializeField] private WheelCollider flWheelCollider;
    [SerializeField] private WheelCollider frWheelCollider;
    [SerializeField] private WheelCollider rlWheelCollider;
    [SerializeField] private WheelCollider rrWheelCollider;

    [SerializeField] private Transform flWheelTransform;
    [SerializeField] private Transform frWheelTransform;
    [SerializeField] private Transform rlWheelTransform;
    [SerializeField] private Transform rrWheelTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (canJump == true)                        //to make sure that the skateboard doesnt jump mid air
            {
                rb.AddForce(transform.up * jump);
                //Quaternion startRotate = gameObject.transform.rotation;
                //Quaternion endRotate = Quaternion.Euler(180, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
                //gameObject.transform.rotation = Quaternion.Lerp(startRotate, endRotate, Time.deltaTime);
                Debug.Log("forcing");
                canJump = false;
            }
        }
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(flWheelCollider, flWheelTransform);
        UpdateSingleWheel(frWheelCollider, frWheelTransform);
        UpdateSingleWheel(rlWheelCollider, rlWheelTransform);
        UpdateSingleWheel(rrWheelCollider, rrWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        //wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void HandleSteering()
    {
        steeringAngle = maxSteeringAngle * hInput;
        flWheelCollider.steerAngle = steeringAngle;
        frWheelCollider.steerAngle = steeringAngle;
    }

    private void HandleMotor()
    {
        flWheelCollider.motorTorque = vInput * speed;
        frWheelCollider.motorTorque = vInput * speed;
    }

    private void GetInput()
    {
        hInput = -Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            canJump = true;
            Debug.Log("Collided");
        }
    }
}
