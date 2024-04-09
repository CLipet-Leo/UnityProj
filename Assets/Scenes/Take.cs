using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Take : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform Hand;
    public TMP_Text text;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = Hand;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("YEEPII");
            text.gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
            text.gameObject.SetActive(false);
    }
}
