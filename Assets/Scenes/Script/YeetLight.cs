using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeetLight : MonoBehaviour
{
    public Light Light;

    public float CurrentLightFuel,
        LightFuel;
    public bool On;

    private void Awake()
    {
        Light = gameObject.GetComponentInChildren<Light>();
    }
    private void Start()
    {
        CurrentLightFuel = LightFuel;
    }

    // Update is called once per frame
    private void Update()
    {
        if (On)
        {
            CurrentLightFuel -= Time.deltaTime;
            Light.intensity = Light.intensity - (LightFuel / CurrentLightFuel) * 0.00003f;
        }
        if (CurrentLightFuel <= 0)
            On = false;
    }
}
