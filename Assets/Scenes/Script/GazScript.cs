using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GazScript : MonoBehaviour
{
    [Header("Gaz")]
    public Transform Hand;
    public GameObject Filter;
    public int delayBeforeCougth;
    public float timeOnGaz; 

    bool OnObject;

    void Start()
    {
        OnObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (true == OnObject)
        {
            timeOnGaz += Time.deltaTime;
            Filter.SetActive(true);
            if (timeOnGaz >= delayBeforeCougth)
            {
                // joue un son en boucle
                Debug.Log("toux");
            }
            if (Hand.childCount != 0)
            {
                if (Hand.GetChild(0).name == "Torch")
                {
                    // Player dies from BOOM !!!
                    Debug.Log("BOOM !!!");
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            OnObject = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            OnObject = false;
            timeOnGaz = 0f;
            Filter.SetActive(false);
            // arrete le son
        }
    }
}
