using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Mouvement : MonoBehaviour
{
    public SlideBarEvent slideBarEvent;

    [Header("Mouvement")]
    public float MS;
    private float MSS;
    public float GroundDrag;

    [Header("OnDurst")]
    public float TitansHeight;
    public LayerMask ThisGround;
    private bool Grounded;

    public Transform orientation;
    private float HInput, VInput, JInput;

    Vector3 MD;

    Rigidbody rb;
    private void Awake()
    {
        slideBarEvent = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SlideBarEvent>();
    }

    private void Start()
    {
        MSS = MS;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        Grounded = Physics.Raycast(transform.position, Vector2.down, TitansHeight * 0.5f + 0.2f, ThisGround);
        //Debug.Log(Grounded);

        MyInput();

        if (Grounded)
            rb.drag = GroundDrag;
        else
            rb.drag = 0.5f;

    }

    private void FixedUpdate()
    {
        MovePLayer();
    }

    private void MyInput()
    {
        HInput = Input.GetAxisRaw("Horizontal");
        VInput = Input.GetAxisRaw("Vertical");
        //JInput = Input.GetAxisRaw("Jump");

        //rb.AddForce(Vector3.up);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (false == slideBarEvent.StateStamina)
                MS = MSS * 1.5f;
            else MS = MSS;

        }
        else MS = MSS;
    }

    private void MovePLayer()
    {
        MD = orientation.forward * VInput + orientation.right * HInput;

        rb.AddForce(MD.normalized * MS * 10f, ForceMode.Force);
    }
}
