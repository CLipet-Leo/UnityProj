using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    private CameraScript cam;

    private float xRotation;
    private float yRotation;



    // Awake is called when the game load
    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("Head").GetComponent<CameraScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // get mouse input
        //float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * cam.sensX;

/*        if (cam.isLockedCam == false)
        {
            yRotation = cam.yRotation;
            xRotation = cam.xRotation;
        }
        else
        {
            yRotation += mouseX;
        
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -30f, 30f);

        }*/

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
