using UnityEngine;

public class GazScript : MonoBehaviour
{
    [Header("Gaz")]
    public Transform Hand;
    public int delayBeforeCougth;

    float timeOnGaz;
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
            if (timeOnGaz >= delayBeforeCougth)
            {
                // joue un son en boucle
            }
            if (Hand.GetChild(0).name == "Torch")
            {
                // Player dies from BOOM !!!
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        OnObject = true;
    }
    private void OnTriggerStay(Collider other)
    {
        // Compte le temps depuis enter
    }
    private void OnTriggerExit(Collider other)
    {
        OnObject = false;
        // arrete le son
    }
}
