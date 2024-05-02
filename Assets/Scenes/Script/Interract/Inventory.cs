using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryPopUp;
    public Transform BackPack;
    public List<GameObject> inventory = new List<GameObject>();
    public List<GameObject> AllTextPopUp = new List<GameObject>();

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
        for (int i = 0; i < inventory.Count; i++)
        {
            Debug.Log(i);
            if (null == inventory[i])
            {
                inventory.RemoveAt(i);
                inventory.Insert(i, Item);
                Item.transform.parent = BackPack;
                Item.transform.position = BackPack.transform.position;
                break;
            }
            else if (Item.GetComponent<Items>().Name == inventory[i].GetComponent<Items>().Name)
            {
                AllTextPopUp[1].SetActive(true);
                StartCoroutine(TextPopUp());
                break;
            }
        }
    }

    IEnumerator TextPopUp()
    {
        yield return new WaitForSeconds(2f);
        foreach(GameObject Text in AllTextPopUp)
        {
            Text.SetActive(false);
        }
    }
}