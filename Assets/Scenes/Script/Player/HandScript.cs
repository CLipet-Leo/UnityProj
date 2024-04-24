using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    [Header("Camera object")]
    public CameraScript cam;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * cam.sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * cam.sensY;

        if (cam.isLockedCam == false)
        {
            yRotation = cam.yRotation;
            xRotation = cam.xRotation;
        }
        else
        {
            yRotation += mouseX;
        
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        }

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
