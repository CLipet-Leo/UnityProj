using System.Collections;
using System.Collections.Generic;
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
            if(null != ThisGameObject)
                InventoryScript.Add_Item_To_Inventory(ThisGameObject);
        }
    }


    private void OnTriggerEnter(Collider ObjectCollider)
    {
        //Prendras le nom de l'object + l'information pour le prendre
        //Stock l'object si pris
        ItemsScript = ObjectCollider.gameObject.GetComponent<Items>();
        if (ObjectCollider.gameObject.TryGetComponent(out Items component))
        {
            for (int i = 0; i < InventoryScript.inventory.Count; i++)
            {
                foreach(GameObject Similar_Items in  InventoryScript.inventory)
                {
                    if (Similar_Items.tag != component.Name)
                    {
                        InteractiveActionText.SetActive(true);
                        ThisGameObject = ObjectCollider.gameObject;
                        Debug.Log("dans la condition");
                    }
                    InteractiveActionText.SetActive(true);
                    Debug.Log("dans le foreach");
                }
                Debug.Log("dans le for");
            }
            if (InventoryScript.inventory.Count == 0)
            {
                InteractiveActionText.SetActive(true);
                ThisGameObject = ObjectCollider.gameObject;
            }
        }
    }

    private void OnTriggerExit()
    {
        //Reset le trigger
        InteractiveActionText.SetActive(false);
    }
}