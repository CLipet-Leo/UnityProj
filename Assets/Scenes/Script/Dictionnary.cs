using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionnary : MonoBehaviour
{
    [SerializeField]
    string ObjectName;

    [SerializeField]
    NewDict newDict;

    Dictionary<string, LightParam> Obj;

    private void Start()
    {
        Obj = newDict.ToDictionary();
    }
}

[Serializable]
public class NewDict
{
    [SerializeField]
    NewDictItem[] DictItems;

    public Dictionary<string, LightParam> ToDictionary()
    {
        Dictionary<string, LightParam> newDict = new Dictionary<string, LightParam>();
        foreach (var item in DictItems)
        {
            newDict.Add(item.Name, item.light);
        }

        return newDict;
    }
}

[Serializable]
public class NewDictItem
{
    [SerializeField]
    public string Name;
    [SerializeField]
    public LightParam light;
}

[Serializable]
public struct LightParam
{
    public float CurrentLightFuel;
    public float LightFuel;
}