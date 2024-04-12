using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.XR;

public class Inventory : MonoBehaviour
{
    // Start is called before the first cum update
    public GameObject BagPrefab, Items;
    public List<GameObject> Invent;
    public TMP_Text text;
    public Transform BackPack;

    private bool OnObject;
    public bool BagEnable;

    private int AllSlots,
        EnableSlots;
    private GameObject[] Slots;

    // Update is called once per frame

    private void Start()
    {
        for (int i = 0; i < BackPack.childCount; i++)
        {
            Invent.Add(BackPack.GetChild(i).gameObject);
        }
        /*        AllSlots = 5;
                Slots = new GameObject[AllSlots];

                for (int i = 0; i < AllSlots; i++)
                {
                    Slots[i] = BagPrefab.transform.GetChild(i).gameObject;
                    if (Slots[i].GetComponent<Slots>().Item == null)
                        Slots[i].GetComponent<Slots>().empty = true;
                }*/
    }

    void Update()
    {
        if (true == OnObject && Input.GetKeyDown(KeyCode.E))
        {
            Invent.Add(Items);
            Debug.Log("Inventory Update 2 ");
            //GetComponent<Rigidbody>().isKinematic = true;
            Items.transform.parent = BackPack;
            Items.transform.position = BackPack.transform.position;
            //transform.parent = Hand;
            //transform.position = Hand.transform.position + new Vector3(0,-0.2f,0.3f) /*+ Vector3.RotateTowards(new Vector3(0, 0, 0.3f), new Vector3(0, 0, 3), 1f ,0.0f)*/;
        }

        if (Input.GetKeyDown(KeyCode.I))
            BagEnable = !BagEnable;

        if (BagEnable)
            BagPrefab.SetActive(true);
        else
            BagPrefab.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            Items = other.gameObject;
            text.gameObject.SetActive(true);
            OnObject = true;

            /*            GameObject ItemPickedUp = other.gameObject;
                        Items Items = ItemPickedUp.GetComponent<Items>();

                        AddItem(ItemPickedUp ,Items.ID, Items.Type, Items.Desc, Items.icon);*/
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
        {
            text.gameObject.SetActive(false);
            OnObject = false;
        }
    }

    private void AddItem(GameObject ItemsObject, int ItemID, string ItemType, string ItemDesc, Sprite ItemIcon)
    {
        for (int i = 0; i <= AllSlots; i++)
        {
            if (Slots[i].GetComponent<Slots>().empty)
            {
                ItemsObject.GetComponent<Items>().PickUp = true;

                Slots[i].GetComponent<Slots>().Item = ItemsObject;
                Slots[i].GetComponent<Slots>().Icon = ItemIcon;
                Slots[i].GetComponent<Slots>().Type = ItemType;
                Slots[i].GetComponent<Slots>().ID = ItemID;
                Slots[i].GetComponent<Slots>().Desc = ItemDesc;

                ItemsObject.transform.parent = Slots[i].transform;
                //ItemsObject.SetActive(false);

                Slots[i].GetComponent<Slots>().UpdateSlot();
                Slots[i].GetComponent<Slots>().empty = false;
            }
            return;
        }
    }
}