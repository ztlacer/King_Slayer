using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Health = 0,
    Equipment = 1,
    Default = 2
}

public class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
    public string name;
    public int cost;
}