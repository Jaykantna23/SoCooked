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
            
            

            
            if ( Input.GetKeyDown(KeyCode.W)) 
            {
                MoveForward();
                // Jump();
                
            }
            }
            
        cameraForward = cameraTransform.forward;
        // cameraForward.y=0f;
        Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turningSpeed*Time.deltaTime * 10f);
        Debug.Log(transform.rotation.eulerAngles);
    }

    private void MoveForward()
    {
        if (cameraTransform == null) return;


        
        // cameraForward.y = 0f;

      
        cameraForward.Normalize();

        
        rb.velocity = cameraForward*moveSpeed;
        Debug.Log(cameraForward);
        Debug.Log(rb.velocity);
        
    }

    
}