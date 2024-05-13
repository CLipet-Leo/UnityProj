using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class TextEventDuration : MonoBehaviour
{
    public GameObject Warnig_Icon;
    public IEnumerator TextDuration(GameObject Text)
    {
        Warnig_Icon.SetActive(true);
        Text.SetActive(true);

        Vector3 WarnigPosNew = Warnig_Icon.transform.position;
        float WarnigPosInit = Warnig_Icon.transform.position.x;
        Vector3 TextPosNew = Text.transform.position;
        float TextPosInit = Text.transform.position.x;

        Debug.Log(TextPosInit);
        Debug.Log(WarnigPosInit);

        while (Warnig_Icon.transform.position.x <= 45)
        {
            Warnig_Icon.transform.position = Vector3.MoveTowards(Warnig_Icon.transform.position, new Vector3(WarnigPosNew.x + 650, WarnigPosNew.y, 0f), 14f);
            Text.transform.position = Vector3.MoveTowards(Text.transform.position, new Vector3(TextPosNew.x + 650, TextPosNew.y, 0f), 14f); ;
            yield return new WaitForSeconds(0.002f);
        }
        yield return new WaitForSeconds(1.5f);

        while (Warnig_Icon.transform.position.x >= -600)
        {
            Warnig_Icon.transform.position = Vector3.MoveTowards(Warnig_Icon.transform.position, new Vector3(WarnigPosInit, WarnigPosNew.y, 0f), 16f);
            Text.transform.position = Vector3.MoveTowards(Text.transform.position, new Vector3(TextPosInit, TextPosNew.y, 0f), 16f); ;
            yield return new WaitForSeconds(0.002f);
        }

        yield return new WaitForSeconds(0.01f);
        Text.SetActive(false);
        Warnig_Icon.SetActive(false);
    }
}
