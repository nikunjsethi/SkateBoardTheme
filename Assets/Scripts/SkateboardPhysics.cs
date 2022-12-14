using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardPhysics : MonoBehaviour
{
    [Header("Physics")]
    Rigidbody rb;
    public float jump = 2000;
    public float speed;
    bool canJump;
    float hInput, vInput;
    float steeringAngle;
    [Header("Wheel Components")]
    [SerializeField] private float maxSteeringAngle;
    [SerializeField] private WheelCollider flWheelCollider;
    [SerializeField] private WheelCollider frWheelCollider;
    [SerializeField] private WheelCollider rlWheelCollider;
    [SerializeField] private WheelCollider rrWheelCollider;

    [SerializeField] private Transform flWheelTransform;
    [SerializeField] private Transform frWheelTransform;
    [SerializeField] private Transform rlWheelTransform;
    [SerializeField] private Transform rrWheelTransform;

    [Header("Audio Components")]
    public AudioSource _source;
    public AudioClip _clip;

    [Header("Scripts")]
    public HealthBar health;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.gameOver == false)
        {
            //SkateBoardCheck();
            if (Input.GetKeyDown(KeyCode.V))
            {
                if (canJump == true)                        //to make sure that the skateboard doesnt jump mid air
                {
                    rb.AddForce(transform.up * jump);
                    canJump = false;
                }
            }

            //if (Input.GetKeyDown(KeyCode.C))
            //{
            //    if (canJump == true)
            //    {
            //        rb.AddForce(transform.up * jump);
            //        //gameObject.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - 30, 0);
            //        Quaternion final= Quaternion.Euler(0, transform.rotation.eulerAngles.y - 30, 0);
            //        gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, final, 0.5f);
            //        canJump = false;
            //    }
            //}

            //if (Input.GetKeyDown(KeyCode.B))
            //{
            //    if (canJump == true)
            //    {
            //        rb.AddForce(transform.up * jump);
            //        Quaternion final = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 30, 0);
            //        gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, final, 0.5f);
            //        canJump = false;
            //    }
            //}
        }
    }
   
    private void FixedUpdate()
    {
        if (health.gameOver == false)
        {
            GetInput();
            HandleMotor();
            HandleSteering();
            UpdateWheels();
        }
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

    private void HandleSteering()                                   //giving steering input 
    {
        steeringAngle = maxSteeringAngle * hInput;
        flWheelCollider.steerAngle = steeringAngle;
        frWheelCollider.steerAngle = steeringAngle;
    }

    private void HandleMotor()
    {
        rlWheelCollider.motorTorque = vInput * speed;
        rrWheelCollider.motorTorque = vInput * speed;
    }

    private void GetInput()                                             //Using Input system to assign W/S/A/D movement
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = -Input.GetAxisRaw("Vertical");
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
        if(other.CompareTag("CranRaspberry"))                           //for health bar
        {
            _source.clip = _clip;
            _source.Play();
            Destroy(other.gameObject);
            health.healthBar.fillAmount += 0.1f;
        }
    }
}
