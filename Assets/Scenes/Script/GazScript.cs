using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GazScript : MonoBehaviour
{
    [SerializeField] AudioSource Src;

    public AudioClip Toux,
        Explosion;

    [Header("Gaz")]
    public PlayerScript Player;
    public Transform Hand;
    public GameObject Filter,
        DeathScreen;
    public int delayBeforeCougth; 
        
    public float timeOnGaz;

    private int count = 0, count2 = 0;
    private bool OnObject;

    private void Start()
    {
        OnObject = false;
    }

    private void Update()
    {
        if (true == OnObject)
        {

            timeOnGaz += Time.deltaTime;
            Filter.SetActive(true);
            if (timeOnGaz >= delayBeforeCougth)
            {
                Src.loop = true;
                // joue un son en boucle
                if (count < 1){
                    Src.clip = Toux;
                    Src.Play();
                    count++;
                    Src.volume = 0.5f;
                    Debug.Log("toux");
                }
            }
            if (Hand.childCount != 0)
            {
                if (Hand.GetChild(0).name == "Torch")
                {
                    // Player dies from BOOM !!!
                    if (count2 < 1)
                    {
                        Src.clip = Explosion;
                        Src.Play();
                        Src.volume = 1;
                        count2++;
                    }
                    Src.loop = false;
                    StartCoroutine(EndSound());
                    Debug.Log("BOOM !!!");
                    // je ne sais pas si c'est ok comme ça, mais well...
                    Destroy(Player);
                    DeathScreen.SetActive(true);
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


    private IEnumerator EndSound()
    {
        yield return new WaitForSeconds(3f);
        Src.Stop();
    }
}
