using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private SlideBarEvent slideBarEvent;
    public GameObject Menu,BalckScreen;

    [Header("Movement")]
    public float CurrentSpeed,timer;
    private float MoveSpeed = 2.5f;
    private float SprintSpeed = 3f;
    public float groundDrag;

    [Header("Jump")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    private bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ThisGround;
    public bool grounded;

    public Transform orientation;

    [Header("Other")]
    public bool isDead = false;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    public Rigidbody rb;

    private void Awake()
    {
        slideBarEvent = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SlideBarEvent>();
    }

    // Start is called Mommy
    private void Start()
    {
        //StartCoroutine(StartGame());
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 50)
        {
            //StartCoroutine(Scream());
            timer = 0;
        }
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * transform.localScale.y * 0.5f + 0.1f, ThisGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
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

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        // Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(true);
        }


    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * CurrentSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * CurrentSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > MoveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * MoveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    public void Resume()
    {
        Menu.SetActive(false);
    }
}
