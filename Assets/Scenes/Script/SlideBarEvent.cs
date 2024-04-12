using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SlideBarEvent : MonoBehaviour
{
    //Do a list of slider for any Object
    public Transform Hand;

    public List<Slider> SliderBar;
    public GameObject obj;
    public float Stamina,
        Fuel,
        Terror;
    public bool StateStamina, 
        GameLaunch, 
        StateFuel, 
        StateTerror;

    private void Start()
    {
        SliderBar[1].gameObject.SetActive(false);

        SliderBar[0].maxValue = Stamina;
        SliderBar[0].value = Stamina;

        SliderBar[2].maxValue = Terror;
        SliderBar[2].value = Terror;

        StateStamina = false;
        StateTerror = false;
        GameLaunch = true;

        StartEventTimer();
    }
    private void StartEventTimer()
    {
        StartCoroutine(StaminaBar());
        StartCoroutine(LightBar());
        StartCoroutine(TerrorBar());
    }
    IEnumerator StaminaBar()
    {
        while (GameLaunch)
        {
            while (false == StateStamina)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    Stamina -= Time.deltaTime * (1.5f * obj.GetComponent<Rigidbody>().mass * 10);
                else if (Stamina <= SliderBar[0].value)
                    Stamina += Time.deltaTime;

                yield return new WaitForSeconds(0.001f);

                if (Stamina <= 0)
                {
                    StateStamina = true;
                }

                if (false == StateStamina)
                {
                    SliderBar[0].value = Stamina;
                }
            }

            while (true == StateStamina)
            {
                Stamina += Time.deltaTime * 2;

                yield return new WaitForSeconds(0.001f);

                if (Stamina >= (SliderBar[0].maxValue*20)/100)
                {
                    StateStamina = false;
                }

                if (true == StateStamina)
                {
                    SliderBar[0].value = Stamina;
                }
            }
        }
    }
    IEnumerator LightBar()
    {
        while (GameLaunch)
        {
            for (int i = 0; i < Hand.childCount; i++)
            {
                if (Hand.GetChild(i).TryGetComponent(out YeetLight light))
                {

                    SliderBar[1].maxValue = light.LightFuel;
                    SliderBar[1].value = light.CurrentLightFuel;
                    if (light.CurrentLightFuel > 0)
                        SliderBar[1].gameObject.SetActive(true);


                    while (true == StateFuel)
                    {
                        SliderBar[1].value -= Time.deltaTime * 3f;
                        SliderBar[1].value = light.CurrentLightFuel;

                        if (light.CurrentLightFuel <= 0)
                        {
                            SliderBar[1].gameObject.SetActive(false);
                            StateFuel = false;
                        }
                        yield return new WaitForSeconds(0.001f);
                    }
                }
            }
            yield return new WaitForSeconds(0.001f);
        }
    }
    IEnumerator TerrorBar()
    {
        while (GameLaunch)
        {

            for(int i = 0; i < Hand.childCount; i++)
            {
               if(Hand.GetChild(i).TryGetComponent(out YeetLight light))
                {
                    while (false == StateTerror)
                    {
                        if (Terror <= SliderBar[2].value && light.CurrentLightFuel >= 0)
                            Terror += Time.deltaTime * 1.5f;
                        else if (Terror >= 0 && light.CurrentLightFuel <= 0)
                            Terror -= Time.deltaTime;

                        SliderBar[2].value = Terror;

                        if (Terror <= 0)
                            StateTerror = true;
                        yield return new WaitForSeconds(0.001f);
                    }
                }
            }

            while (Hand.childCount == 0)
            {

                Terror -= Time.deltaTime;
                SliderBar[2].value = Terror;
                if (Terror <= 0)
                {
                    StateTerror = true;
                }
                yield return new WaitForSeconds(0.001f);
            }
        }
    }
}