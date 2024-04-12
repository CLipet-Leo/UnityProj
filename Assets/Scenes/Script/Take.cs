using TMPro;
using UnityEngine;

public class Take : MonoBehaviour
{
    // Start is called before the first frame update
    public YeetLight YeetLight;
    public int ID;
    public List<GameObject> Inventory;
    public Transform Hand, 
        BackPack;
    public TMP_Text text;
    private bool OnObject;

    private void Awake()
    {
        YeetLight = GetComponent<YeetLight>();
    }

    private void Start()
    {
        OnObject = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (true == OnObject && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = BackPack;
            transform.position = BackPack.transform.position;
            //transform.parent = Hand;
            //transform.position = Hand.transform.position + new Vector3(0,-0.2f,0.3f) /*+ Vector3.RotateTowards(new Vector3(0, 0, 0.3f), new Vector3(0, 0, 3), 1f ,0.0f)*/;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ID = 1;
            for (int i = 0; i < BackPack.childCount; i++)
            {
                if (BackPack.transform.GetChild(i).gameObject.GetComponent<Items>().ID == ID)
                {
                    Inventory[1].transform.parent = BackPack;
                    Inventory[1].transform.position = BackPack.transform.position + new Vector3(0, -0.2f, 0.3f) /*+ Vector3.RotateTowards(new Vector3(0, 0, 0.3f), new Vector3(0, 0, 3), 1f ,0.0f)*/;
                    YeetLight.On = true;
                    GetComponent<Rigidbody>().isKinematic = true;
                    Inventory[0].transform.parent = Hand;
                    Inventory[0].transform.position = Hand.transform.position + new Vector3(0, -0.2f, 0.3f) /*+ Vector3.RotateTowards(new Vector3(0, 0, 0.3f), new Vector3(0, 0, 3), 1f ,0.0f)*/;
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
                    Inventory[0].transform.parent = BackPack;
                    Inventory[0].transform.position = BackPack.transform.position + new Vector3(0, -0.2f, 0.3f) /*+ Vector3.RotateTowards(new Vector3(0, 0, 0.3f), new Vector3(0, 0, 3), 1f ,0.0f)*/;
                    YeetLight.On = true;
                    GetComponent<Rigidbody>().isKinematic = true;
                    Inventory[1].transform.parent = Hand;
                    Inventory[1].transform.position = Hand.transform.position + new Vector3(0, -0.2f, 0.3f) /*+ Vector3.RotateTowards(new Vector3(0, 0, 0.3f), new Vector3(0, 0, 3), 1f ,0.0f)*/;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
           for (int i = 0;i < Hand.childCount; i++)
            {
                Inventory[i].transform.parent = BackPack;
                Inventory[i].transform.position = BackPack.transform.position + new Vector3(0, -0.2f, 0.3f) /*+ Vector3.RotateTowards(new Vector3(0, 0, 0.3f), new Vector3(0, 0, 3), 1f ,0.0f)*/;
            }
           YeetLight.On = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            text.gameObject.SetActive(true);
            OnObject = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            text.gameObject.SetActive(false);
            OnObject = false;
        }
    }
}
