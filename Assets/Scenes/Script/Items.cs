using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private YeetLight yeetLight;

    public int ID;
    public string Type, Desc;
    public Sprite icon;

    public bool PlayerObject;
    [HideInInspector]
    public bool PickUp, Equiped;
    [HideInInspector]
    public GameObject Lighting;

    public GameObject LightManager;

    private void Awake()
    {
        yeetLight = GetComponent<YeetLight>();
    }

    private void Start()
    {

/*        if (false == PlayerObject)
        {
            int AllLight = LightManager.transform.childCount;
            for (int i = 0; i < AllLight; i++)
            {
                if (LightManager.transform.GetChild(i).gameObject.GetComponent<Items>().ID == ID)
                {
                    Lighting = LightManager.transform.GetChild(i).gameObject;
                }
            }
        }*/
    }

    private void Update()
    {
        if (true == Equiped)
        {
            if (Input.GetKeyDown(KeyCode.G))
                Equiped = false;
            if (Equiped)
                this.gameObject.SetActive(false);
        }
    }

    public void ItemUsege()
    {
        if (Type == "Light")
        {
            Lighting.SetActive(true);
            Lighting.transform.parent = Lighting.GetComponent<Take>().BackPack;
            yeetLight.On = true;
            Equiped = true;
        }
    }
}