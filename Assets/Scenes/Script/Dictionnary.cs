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

    Dictionary<string, GameObject> Obj;

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

    public Dictionary<string, GameObject> ToDictionary()
    {
        Dictionary<string, GameObject> newDict = new Dictionary<string, GameObject>();
        foreach (var item in DictItems)
        {
            newDict.Add(item.Name, item.obj);
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
    public GameObject obj;
}