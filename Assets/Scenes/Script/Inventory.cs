using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> Invent;
    //public Take Take;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
/*        if (true == Take.OnObject && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            Invent.Add(gameObject);
            transform.parent = Take.BackPack;
            transform.position = Take.BackPack.transform.position;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Torch")
        {
            Debug.Log("eadadadadadadf");
        }
        if(other.tag == "Player")
        {
            Debug.Log("eadadadadadadf");
        }
        Debug.Log("44");

    }
}
