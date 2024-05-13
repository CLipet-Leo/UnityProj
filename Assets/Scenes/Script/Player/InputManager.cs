using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private KeyCode Keys;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {

    }


    public KeyCode Alpha_num_Keyboard()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Keys = KeyCode.Alpha1;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            Keys = KeyCode.Alpha2;

        if (Input.GetKeyDown(KeyCode.Alpha3))
            Keys = KeyCode.Alpha3;

        if (Input.GetKeyDown(KeyCode.Alpha4))
            Keys = KeyCode.Alpha4;

        if (Input.GetKeyDown(KeyCode.Alpha5))
            Keys = KeyCode.Alpha5;

        return Keys;
    }

    public int Convert_KeyCode_To_Int(KeyCode Ikey)
    {
        return (int)Ikey - 49;
    }
}
