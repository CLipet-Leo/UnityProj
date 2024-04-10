using TMPro;
using UnityEngine;

public class Take : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform Hand;
    public TMP_Text text;
    private bool OnObject;

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
            transform.parent = Hand;
            transform.position = Hand.transform.position + new Vector3(0,-0.2f,0.3f) /*+ Vector3.RotateTowards(new Vector3(0, 0, 0.3f), new Vector3(0, 0, 3), 1f ,0.0f)*/;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        text.gameObject.SetActive(true);
        OnObject = true;
    }
    private void OnTriggerExit(Collider other)
    {
        text.gameObject.SetActive(false);
        OnObject = false;
    }
}
