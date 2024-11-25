using UnityEngine;
using Cinemachine;

public class LandMovement : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public float moveSpeed = 5f;
    public float jumpVelocity = 7f;
    public float turningSpeed = 5f;
    public Rigidbody rb;

    private Transform cameraTransform;
    private bool isGrounded;
    Vector3 cameraForward;

    void Start()
    {
        Cursor.visible = false;
        if (freeLookCamera != null)
        {
            cameraTransform = GameObject.FindWithTag("MainCamera").transform;
        }
        else
        {
            //.LogError("Cinemachine FreeLook Camera is not assigned!");
        }


        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {


        {




            if (isGrounded && Input.GetKeyDown(KeyCode.W))
            {
                MoveForward();
                Jump();

            }
        }

        cameraForward = cameraTransform.forward;
        cameraForward.y = 0f;
        Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turningSpeed * Time.deltaTime * 10f);
        //.Log(transform.rotation.eulerAngles);
    }

    private void MoveForward()
    {
        if (cameraTransform == null) return;



        cameraForward.y = 0f;


        cameraForward.Normalize();


        rb.velocity = cameraForward * moveSpeed;
        //.Log(cameraForward);
        //.Log(rb.velocity);

    }

    private void Jump()
    {

        Vector3 velocity = rb.velocity;
        velocity.y += jumpVelocity;
        rb.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
