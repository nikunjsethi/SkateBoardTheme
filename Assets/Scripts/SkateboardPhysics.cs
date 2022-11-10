using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardPhysics : MonoBehaviour
{
    public GameObject thirdPersonCamera;
    Rigidbody rb;
    public float jump = 2000;
    public float speed;
    public Vector3 startRotation;
    public Vector3 endRotation;
    bool canJump;
    public float desiredDuration;
    float elapsedTime;
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
        //    elapsedTime += Time.deltaTime;
        //float percentageComplete = elapsedTime / desiredDuration;
            if (canJump == true)                        //to make sure that the skateboard doesnt jump mid air
            {
                rb.AddForce(transform.up * jump);
                //transform.rotation = Quaternion.Slerp(Quaternion.Euler(startRotation), Quaternion.Euler(endRotation), percentageComplete);
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
        hInput = Input.GetAxis("Horizontal");
        vInput = -Input.GetAxis("Vertical");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            canJump = true;
            Debug.Log("Collided");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CranRaspberry"))
        {
            Destroy(other.gameObject);
        }
    }
}
