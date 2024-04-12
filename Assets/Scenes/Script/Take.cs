using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Take : MonoBehaviour
{

    [SerializeField] AudioSource Src;

    public AudioClip Torch;

    // Start is called before the first sex update
    public YeetLight YeetLight;
    public Inventory Inventory;
    public int ID;
    public int count = 0;
    public Transform Hand,
        BackPack;

    private void Awake()
    {
        YeetLight = GetComponent<YeetLight>();
        Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ID = 1;
            for (int i = 0; i < BackPack.childCount; i++)
            {
                if (BackPack.transform.GetChild(i).gameObject.GetComponent<Items>().ID == ID)
                {
                    Inventory.Invent[0].SetActive(true);
                    YeetLight.On = true;
                    Inventory.Invent[0].transform.parent = Hand;
                    Inventory.Invent[0].transform.rotation = Hand.transform.rotation;
                    Inventory.Invent[0].transform.position = Hand.transform.position + new Vector3(0, -0.2f, 0.3f) /*+ Vector3.RotateTowards(new Vector3(0, 0, 0.3f), new Vector3(0, 0, 3), 1f ,0.0f)*/;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ID = 2;
            for (int i = 0; i < BackPack.childCount; i++)
            {
                if (BackPack.transform.GetChild(i).gameObject.GetComponent<Items>().ID == ID)
                {
                    Inventory.Invent[1].SetActive(true);

                    YeetLight.On = true;
                    Inventory.Invent[1].transform.parent = Hand;
                    Inventory.Invent[1].transform.position = Hand.transform.position + new Vector3(0, -0.2f, 0.3f) /*+ Vector3.RotateTowards(new Vector3(0, 0, 0.3f), new Vector3(0, 0, 3), 1f ,0.0f)*/;
                }
            }
        }

        if (Hand.childCount != 0)
        {
            if (Hand.GetChild(0).name == "Torch")
            {
                Debug.Log("Torch comme nom");
                if (count < 1)
                {
                    Src.clip = Torch;
                    Src.Play();
                    count++;
                }
                Src.loop = true;
            }
            else
            {
                count = 0;
                Src.loop = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            for (int i = 0; i < Inventory.Invent.Count; i++)
            {
                Inventory.Invent[i].SetActive(false);
                Inventory.Invent[i].transform.parent = BackPack;
                Inventory.Invent[i].transform.position = BackPack.transform.position + new Vector3(0, -0.2f, 0.3f) /*+ Vector3.RotateTowards(new Vector3(0, 0, 0.3f), new Vector3(0, 0, 3), 1f ,0.0f)*/;
            }
            YeetLight.On = false;
        }
    }
}