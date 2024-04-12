using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BagPrefab; 
    public bool BagEnable;

    private int AllSlots,
        EnableSlots;
    private GameObject[] Slots;

    // Update is called once per frame

    private void Start()
    {
        AllSlots = 5;
        Slots = new GameObject[AllSlots];

        for (int i = 0; i < AllSlots; i++)
        {
            Slots[i] = BagPrefab.transform.GetChild(i).gameObject;
            if (Slots[i].GetComponent<Slots>().Item == null)
                Slots[i].GetComponent<Slots>().empty = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            BagEnable = !BagEnable;

        if(BagEnable)
            BagPrefab.SetActive(true);
        else
            BagPrefab.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            //GameObject ItemPickedUp = other.gameObject;
            //Items Items = ItemPickedUp.GetComponent<Items>();

            //AddItem(ItemPickedUp ,Items.ID, Items.Type, Items.Desc, Items.icon);
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
