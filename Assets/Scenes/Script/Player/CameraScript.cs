using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Header("Sensibility")]
    public float sensX;
    public float sensY;

    [Header("Orientation")]
    public Transform orientation;

    [Header("Other")]
    public bool isLockedCam;

    public float xRotation;
    public float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isLockedCam = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // get mouse input<
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        if (Input.GetMouseButton(2))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isLockedCam = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isLockedCam = false;

            // rotate cam and orientation
            yRotation += mouseX;
        
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
