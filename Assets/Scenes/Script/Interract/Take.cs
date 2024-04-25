using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
    
public class Take : MonoBehaviour
{
    //Prendre une list Item 
    [Header("------ExternScript------")]
    public Inventory InventoryScript;
    public Items ItemsScript;

    [Header("------InternScript------")]
    public GameObject ThisGameObject, 
        InteractiveActionText;
    public Transform Hand;
    
    private void Awake()
    {
        //ItemsScript = GameObject.GetComponent<Items>();
        InventoryScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Inventory>();
    }

    private void Update()
    {
        Action_Input();
    }

    private void Action_Input()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ThisGameObject.transform.parent = Hand;
            ThisGameObject.transform.rotation = Hand.transform.rotation;
            ThisGameObject.transform.position = Hand.transform.position + new Vector3(0, -0.2f, 0.3f);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            InventoryScript.Add_Item_To_Inventory(ThisGameObject);

            Debug.Log("Key E Down");
        }
    }


    private void OnTriggerEnter(Collider ObjectCollider)
    {
        //Prendras le nom de l'object + l'information pour le prendre
        //Stock l'object si pris
        ItemsScript = ObjectCollider.gameObject.GetComponent<Items>();
        if (ObjectCollider.gameObject.TryGetComponent(out Items component))
        {
            InteractiveActionText.SetActive(true);
            foreach(GameObject Similar_Items in InventoryScript.inventory)
            {
                if (component.Name != Similar_Items.GetComponent<Items>().Name)
                    ThisGameObject = ObjectCollider.gameObject;
            }
            if (InventoryScript.inventory.Count == 0)
                ThisGameObject = ObjectCollider.gameObject;
        }
    }

    //Reset le trigger
    private void OnTriggerExit()
    {
        InteractiveActionText.SetActive(false);
        //Verifie que l'item est bien dans l'inventaire
        foreach (GameObject Similar_Items in InventoryScript.inventory)
        {
            if (null != ThisGameObject && Similar_Items.GetComponent<Items>().Name == ThisGameObject.GetComponent<Items>().Name)
                ThisGameObject.GetComponent<BoxCollider>().isTrigger = false;
        }

        //Reset la Variable -> Null
        ThisGameObject = null;
    }
}