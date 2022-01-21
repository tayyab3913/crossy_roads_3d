using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cameraToFollow;
    public GameObject secondCameraToFollow;
    public bool isGrounded;
    public bool gameOver = false;
    public float horizontalInput;
    public float verticalInput;
    public float movementSpeed;
    public float jumpForce;
    public float directionalForce;
    public float xAxisOffset;
    public float yAxisOffset;
    public float gravityModifier;
    public float zAxisOffset;
    public float boundry = 30;
    private Vector3 offsetPosition;
    private Rigidbody playerRb;
    private Camera cam1;
    private Camera cam2;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;

        playerRb = GetComponent<Rigidbody>();
        cam1 = cameraToFollow.GetComponent<Camera>();
        cam2 = secondCameraToFollow.GetComponent<Camera>();

        cam1.enabled = true;
        cam2.enabled = false;

        offsetPosition = new Vector3(xAxisOffset, yAxisOffset, zAxisOffset);

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCamera();
        if(gameOver == false)
        {
            PlayerMovementByJump();
        }
        cameraToFollow.transform.position = new Vector3(transform.position.x, 10f, transform.position.z) + new Vector3(offsetPosition.x, 0f, offsetPosition.z);
        secondCameraToFollow.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) + new Vector3(10, 7, 0);
        StayInbounds();
    }

    void PlayerMovementByJump()
    {
        if(Input.GetKey(KeyCode.LeftArrow) && isGrounded)
        {
            Jump();
            isGrounded = false;
            ImpulseDirection(Vector3.left);
        } else if (Input.GetKey(KeyCode.RightArrow) && isGrounded)
        {
            Jump();
            isGrounded = false;
            ImpulseDirection(Vector3.right);
        }
        else if(Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
            isGrounded = false;
            ImpulseDirection(Vector3.forward);
        } else if (Input.GetKey(KeyCode.DownArrow) && isGrounded)
        {
            Jump();
            isGrounded = false;
            ImpulseDirection(Vector3.back);
        }

        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * movementSpeed);
        //transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * movementSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void StayInbounds()
    {
        if(transform.position.x < -boundry)
        {
            transform.position = new Vector3(-boundry, transform.position.y, transform.position.z);
        } else if (transform.position.x > boundry)
        {
            transform.position = new Vector3(boundry, transform.position.y, transform.position.z);
        }
    }

    void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void ImpulseDirection(Vector3 direction)
    {
        playerRb.AddForce(direction * directionalForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void PlayerDied()
    {
        playerRb.AddForce(Vector3.up * 2000, ForceMode.Impulse);
        gameOver = true;
        Debug.Log("!!! Game Over !!!");
    }

    void SwitchCamera()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }
    }

    public void InitializePlayer(GameObject camera, GameObject sCamera, float speed, float jForce, float dForce, float xOffset, float yOffset, float zOffset, float gModifier, float inputBoundry)
    {
        cameraToFollow = camera;
        secondCameraToFollow = sCamera;
        movementSpeed = speed;
        jumpForce = jForce;
        directionalForce = dForce;
        xAxisOffset = xOffset;
        yAxisOffset = yOffset;
        zAxisOffset = zOffset;
        gravityModifier = gModifier;
        boundry = inputBoundry;
    }
}
