using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;

public class SlideBarEvent : MonoBehaviour
{
    //Do a list of slider for any Object
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
        SliderBar[0].maxValue = Stamina;
        SliderBar[0].value = Stamina;
        SliderBar[1].maxValue = Fuel;
        SliderBar[1].value = Fuel;
        SliderBar[2].maxValue = Terror;
        SliderBar[2].value = Terror;

        StateStamina = false;
        StateTerror = true;
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
            while (true == StateTerror)
            {

                Debug.Log("Yeeepii");
                yield return new WaitForSeconds(0.001f);
            }
        }
    }
    IEnumerator TerrorBar()
    {
        while (GameLaunch)
        {
            while (true == StateTerror)
            {

                Terror -= Time.deltaTime * 1.5f;
                if (Terror >= 0)
                    SliderBar[2].value = Terror;

                yield return new WaitForSeconds(0.001f);
            }
        }
    }
}
