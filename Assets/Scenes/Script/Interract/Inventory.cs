using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryPopUp;

    public Transform BackPack;
    public List<GameObject> inventory = new List<GameObject>();
    private bool StateInventoryPopUp;
    private void Awake()
    {
        BackPack = GameObject.FindGameObjectWithTag("BackPack").GetComponent<Transform>();
    }

    private void Start()
    {
        InventoryPopUp.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && false == StateInventoryPopUp)
        {
            InventoryPopUp.SetActive(true);
            StateInventoryPopUp = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && true == StateInventoryPopUp)
        {
            InventoryPopUp.SetActive(false);
            StateInventoryPopUp = false;
        }
    }

    public void Add_Item_To_Inventory(GameObject Item)
    {
/*        Debug.Log("Debut Terciere");
        for (int i = 0; i <= (i < inventory.Count ? i : 0); i++)
        {
            Debug.Log("dans Terciere avant null");
            if (inventory.Count > 0 && null == inventory[i])
            {
                inventory.Insert(i, Item);
                Debug.Log("Null");
            }
            else
                inventory.Add(Item);
            Debug.Log("For Terciere");
        }*/
        //if(inventory.Count == 0)
            inventory.Add(Item);

        Item.transform.parent = BackPack;
        Item.transform.position = BackPack.transform.position;
        Debug.Log("In void for add item");
    }
}