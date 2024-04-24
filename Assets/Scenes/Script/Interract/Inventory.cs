using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryPopUp;

    public Transform BackPack;
    private List<GameObject> inventory = new List<GameObject>();
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
        if (Input.GetKey(KeyCode.I) && false == StateInventoryPopUp)
        {
            InventoryPopUp.SetActive(true);
            StateInventoryPopUp = true;
        }
        else if(Input.GetKey(KeyCode.I) && true == StateInventoryPopUp)
        {
            InventoryPopUp.SetActive(false);
            StateInventoryPopUp= false;
        }
    }

    public void Add_Item_To_Inventory(GameObject Item)
    {
        inventory.Add(Item);
        Item.transform.parent = BackPack;
    }

}