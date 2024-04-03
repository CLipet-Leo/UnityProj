using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject go;
    public float Speed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) {go.transform.position += new Vector3(0, 0, Speed);}
        if(Input.GetKeyDown(KeyCode.Q)) { go.transform.position += new Vector3(Speed, 0, 0);}
        if(Input.GetKeyDown(KeyCode.S)) { go.transform.position += new Vector3(0, 0, -Speed); }
        if(Input.GetKeyDown(KeyCode.D)) { go.transform.position += new Vector3(-Speed, 0, 0); }
    }
}
