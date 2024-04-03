using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        print("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            GetComponent<Transform>().position += new Vector3(0, movementSpeed, 0);
        if (Input.GetKeyDown(KeyCode.S))
            GetComponent<Transform>().position += new Vector3(0, -movementSpeed, 0);
        if (Input.GetKeyDown(KeyCode.A))
            GetComponent<Transform>().position += new Vector3(-movementSpeed, 0, 0);
        if (Input.GetKeyDown(KeyCode.D))
            GetComponent<Transform>().position += new Vector3(movementSpeed, 0, 0);
    }
}
