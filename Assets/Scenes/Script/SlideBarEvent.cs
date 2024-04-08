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
    public Slider SliderBar;
    public GameObject obj;
    public float Stamina;
    public bool StateStamina, GameLaunch;

    private void Start()
    {
        SliderBar.maxValue = Stamina;
        SliderBar.value = Stamina;
        StartEventTimer();
    }
    private void StartEventTimer()
    {
        StateStamina = false;
        GameLaunch = true;
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        while (GameLaunch)
        {
            while (false == StateStamina)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    Stamina -= Time.deltaTime * (1.5f * obj.GetComponent<Rigidbody>().mass * 10);
                else if (Stamina <= SliderBar.value)
                    Stamina += Time.deltaTime;

                yield return new WaitForSeconds(0.001f);

                if (Stamina <= 0)
                {
                    StateStamina = true;
                }

                if (false == StateStamina)
                {
                    SliderBar.value = Stamina;
                }

            }
            while (true == StateStamina)
            {
                Stamina += Time.deltaTime * 2;

                yield return new WaitForSeconds(0.001f);

                if (Stamina >= (SliderBar.maxValue*20)/100)
                {
                    StateStamina = false;
                }

                if (true == StateStamina)
                {
                    SliderBar.value = Stamina;
                }
            }
        }
    }
}
