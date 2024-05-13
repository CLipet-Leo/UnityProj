using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;
    
public class Take : MonoBehaviour
{
    //Prendre une list Item 
    [Header("------ExternScript------")]
    public Inventory InventoryScript;
    public Items ItemsScript;
    public InputManager InputManagerScript;
    public TextEventDuration TextEventDurationScript;

    [Header("------InternScript------")]
    public GameObject ThisGameObject; 
    public GameObject U_Can_Take_Text, 
        Hand_full_Text;
    public Transform Hand, 
        BackPack;

    private int GetItemWithValue;
    
    private void Awake()
    {
        //Add correctly script specifie
        //ItemsScript = GameObject.GetComponent<Items>();
        InventoryScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Inventory>();
        InputManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<InputManager>();
        TextEventDurationScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TextEventDuration>();

        // Add correctly transform specifie
        Hand = GameObject.FindGameObjectWithTag("Hand").transform;
        BackPack = GameObject.FindGameObjectWithTag("BackPack").transform;
    }

    private void Update()
    {
        //Debug.Log(InputManagerScript.Alpha_num_Keyboard());
        Action_Input();
    }

    private void Action_Input()
    {
        /*
         * Using InputManger
         * Select Item with Alpha_num "Input"
         */

        if (Input.GetKeyDown(InputManagerScript.Alpha_num_Keyboard()))
        {
            GetItemWithValue = InputManagerScript.Convert_KeyCode_To_Int(InputManagerScript.Alpha_num_Keyboard());

            if (0 == Hand.childCount && null != InventoryScript.inventory[GetItemWithValue])
            {
                if(null != ThisGameObject)
                {
                    ThisGameObject.transform.parent = BackPack;
                    ThisGameObject.transform.position = BackPack.position;
                }
                ThisGameObject = InventoryScript.inventory[GetItemWithValue];
                ThisGameObject.transform.parent = Hand;
                ThisGameObject.transform.rotation = Hand.rotation;
                ThisGameObject.transform.position = Hand.position + new Vector3(0, -0.2f, 0.3f);
            }
            else if (0 < Hand.childCount)
                StartCoroutine(TextEventDurationScript.TextDuration(Hand_full_Text));

        }

        /*
        * Pick item with "E" Input
        * Replace Item in ur Back with "G" Input
        */

        if (Input.GetKeyDown(KeyCode.E) && true == ThisGameObject.GetComponent<BoxCollider>().isTrigger)
        {
            ThisGameObject.GetComponent<BoxCollider>().isTrigger = false;
            InventoryScript.Add_Item_To_Inventory(ThisGameObject);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            ThisGameObject.transform.parent = BackPack;
            ThisGameObject.transform.position = BackPack.position;
            ThisGameObject = null;
        }
    }
    private void OnTriggerEnter(Collider ObjectCollider)
    {
        //Prendras le nom de l'object + l'information pour le prendre
        //Stock l'object si pris
        ItemsScript = ObjectCollider.gameObject.GetComponent<Items>();
        if (ObjectCollider.gameObject.TryGetComponent(out Items component))
        {
            U_Can_Take_Text.SetActive(true);
            ThisGameObject = ObjectCollider.gameObject;
        }
    }

    //Reset le trigger
    private void OnTriggerExit()
    {
        U_Can_Take_Text.SetActive(false);
        //Verifie que l'item est bien dans l'inventaire
        for (int i = 0; i < InventoryScript.inventory.Count; i++)
        {
            if (null == InventoryScript.inventory[i])
            {
                continue;
            }
            else if (null != ThisGameObject && ThisGameObject.GetComponent<Items>().Name != InventoryScript.inventory[i].GetComponent<Items>().Name)
            {
                continue;
            }
            else
                break;
        }
        //Reset la Variable -> Null
        ThisGameObject = null;
    }
}