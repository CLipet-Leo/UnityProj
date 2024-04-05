using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float SensX, SensY;
    public Transform Orientation;

    private float RotaX, RotaY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SensX;
        float MouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SensY;

        RotaY += MouseX;
        RotaX -= MouseY;

        RotaX = Mathf.Clamp(RotaX, -90f, 90f);

        transform.rotation = Quaternion.Euler(RotaX, RotaY, 0);
        Orientation.rotation = Quaternion.Euler(0, RotaY, 0);
    }
}
