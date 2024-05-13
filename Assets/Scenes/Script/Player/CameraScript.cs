using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float xRotation;
    public float sensX;
    public Transform orientation;

    private void Update()
    {
    
        float mouseX = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensX;

        // rotate cam and orientation
        xRotation -= mouseX;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);

        // Apply rotation on Axe Y and X
        orientation.rotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
