using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
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

    private void Start()
    {
        MSS = MS;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        Grounded = Physics.Raycast(transform.position, Vector2.down, TitansHeight * 0.5f + 0.2f, ThisGround);

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
            MS = MSS * 1.5f;
        }
        else MS = MSS;
    }

    private void MovePLayer()
    {
        MD = orientation.forward * VInput + orientation.right * HInput;

        rb.AddForce(MD.normalized * MS * 10f, ForceMode.Force);
    }
}
