using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Take : MonoBehaviour
{
    //Prendre une list Item 
    [Header("------ExternScript------")]
    public Inventory InventoryScript;
    public Items ItemsScript;

    [Header("------InternScript------")]
    public GameObject GameObject, 
        InteractiveActionText;
    public Transform Hand;
    
    private void Awake()
    {
        //ItemsScript = GameObject.GetComponent<Items>();
        InventoryScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject.transform.parent = Hand;
            GameObject.transform.rotation = Hand.transform.rotation;
            GameObject.transform.position = Hand.transform.position + new Vector3(0, -0.2f, 0.3f);
        }
    }

    private void OnTriggerEnter()
    {
        //Prendras le nom de l'object + l'information pour le prendre
        //Stock l'object si pris
        if (true == ItemsScript.Interactive)
        {
            InteractiveActionText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                InventoryScript.Add_Item_To_Inventory(GameObject);
            }
        }
    }

    private void OnTriggerExit()
    {
        //Reset le trigger
        InteractiveActionText.SetActive(false);
    }
}