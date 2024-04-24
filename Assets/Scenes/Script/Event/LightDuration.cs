using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class LightDuration : Items
{
    public Light Light;

    public bool On;

    //Add a light of Hierarchy to Inspector -> Light
    //Add a Script of Hierarchy to Inspector -> Items
    private void Awake()
    {
        Light = gameObject.GetComponentInChildren<Light>();
    }
    private void Start()
    {
        CurrentFuell = Fuell;
    }

    // Update is called once per frame
    private void Update()
    {
        if (On)
        {
            CurrentFuell -= Time.deltaTime;
            Light.intensity = Light.intensity - (Fuell / CurrentFuell) * 0.00003f;
        }

        if (CurrentFuell <= 0)
        {
            On = false;
            Destroy(gameObject);
        }
    }
}
