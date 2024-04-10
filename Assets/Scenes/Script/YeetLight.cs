using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeetLight : MonoBehaviour
{
    public float CurrentLightFuel,
        LightFuel;
    public bool On;

    void Start()
    {
        CurrentLightFuel = LightFuel;
    }

    // Update is called once per frame
    void Update()
    {
        if (On)
            CurrentLightFuel -= Time.deltaTime;
        if (CurrentLightFuel <= 0)
            On = false;
    }
}
