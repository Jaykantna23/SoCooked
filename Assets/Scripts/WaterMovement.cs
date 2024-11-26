using UnityEngine;
using Cinemachine;

public class WaterMovement : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public float moveSpeed = 5f;
    //public float jumpVelocity = 7f;     
    public float turningSpeed = 5f;
    public Rigidbody rb;
                  

    private Transform cameraTransform;
    // private bool isGrounded;

    Vector3 cameraForward;

    void Start()
    {

        if (freeLookCamera != null)
        {
            cameraTransform = GameObject.FindWithTag("MainCamera").transform;
        }
        else
        {
            Debug.LogError("Cinemachine FreeLook Camera is not assigned!");
        }


        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {


        {




            if (Input.GetKeyDown(KeyCode.W))
            {
                MoveForward();
                // Jump();

            }
        }

        cameraForward = cameraTransform.forward;
        // cameraForward.y=0f;
        Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turningSpeed * Time.deltaTime * 10f);
        Debug.Log(transform.rotation.eulerAngles);
    }

    private void MoveForward()
    {
        if (cameraTransform == null) return;



        // cameraForward.y = 0f;


        cameraForward.Normalize();


        rb.velocity = cameraForward * moveSpeed;
        Debug.Log(cameraForward);
        Debug.Log(rb.velocity);

    }


}


// using UnityEngine;
// using Cinemachine;

// public class WaterMovement : MonoBehaviour
// {
//     public CinemachineFreeLook freeLookCamera;
//     public float moveSpeed = 5f;
//     public float turningSpeed = 5f;
//     public Rigidbody rb;
//     public float decreaseSpeed = 2f; // Positive value to decrease speed

//     private Transform cameraTransform;
//     Vector3 cameraForward;

//     void Start()
//     {
//         if (freeLookCamera != null)
//         {
//             cameraTransform = GameObject.FindWithTag("MainCamera").transform;
//         }
//         else
//         {
//             Debug.LogError("Cinemachine FreeLook Camera is not assigned!");
//         }

//         if (rb == null)
//         {
//             rb = GetComponent<Rigidbody>();
//         }
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.W))
//         {
//             MoveForward();
//         }
//         else if (Input.GetKeyDown(KeyCode.S))
//         {
//             DecreaseSpeed();
//         }

//         cameraForward = cameraTransform.forward;

//         Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
//         transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turningSpeed * Time.deltaTime * 10f);
//     }

//     private void MoveForward()
//     {
//         if (cameraTransform == null) return;

//         cameraForward.Normalize();
//         rb.velocity = cameraForward * moveSpeed;
//         Debug.Log("Move Forward Velocity: " + rb.velocity);
//     }

//     private void DecreaseSpeed()
//     {
//         // Reduce speed but ensure it does not go below zero
//         moveSpeed = Mathf.Max(0.1f, moveSpeed - decreaseSpeed);

//         // Update velocity to reflect the decreased speed
//         if (rb.velocity.magnitude >= 0)
//         {
//             rb.velocity = cameraForward * moveSpeed;
//         }

//         Debug.Log("Speed decreased. Current Speed: " + moveSpeed);
//     }
// }
