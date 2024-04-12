using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour, IPointerClickHandler
{
    public GameObject Item;
    public int ID;
    public string Type, Desc;
    public bool empty;

    public Transform SlotIcon;
    public Sprite Icon;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UseItems();
    }


    private void Start()
    {
        //SlotIcon = transform.GetChild(0);
    }

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = Icon;
    }

    public void UseItems()
    {
        Item.GetComponent<Items>().ItemUsege();
    }
}