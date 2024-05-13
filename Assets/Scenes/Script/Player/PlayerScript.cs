using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private SlideBarEvent slideBarEvent;

    [Header("Sensibility")]
    public float sensY;
    public float sensX;

    [Header("Movement")]
    public float CurrentSpeed;
    private float MoveSpeed = 2.5f;
    private float SprintSpeed = 3f;
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ThisGround;
    public bool grounded;

    [Header("Orientation")]
    public Transform orientation;
    public Transform orientationCam;
    private float horizontalInput;
    private float verticalInput;
    private float yRotation;
    private float xRotation;

    private Vector3 moveDirection;

    public Rigidbody rb;

    private void Awake()
    {
        //slideBarEvent = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SlideBarEvent>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * transform.localScale.y * 0.5f + 0.1f, ThisGround);

        MyInput();

        CameraMouvement();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }
    private void FixedUpdate() //50 frame
    {
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (false == slideBarEvent.StateStamina)
                CurrentSpeed = MoveSpeed * SprintSpeed;
        }
        else CurrentSpeed = MoveSpeed;
    }
    private void CameraMouvement()
    {
        float mouseY = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensY;
        float mouseX = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensX;

        // rotate cam and orientation
        yRotation += mouseY;
        xRotation -= mouseX;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);

        // Apply rotation on Axe Y and X
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        orientationCam.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * CurrentSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * CurrentSpeed * 10f , ForceMode.Force);
    }
}
