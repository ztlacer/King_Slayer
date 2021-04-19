using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Queen,
    Bishop,
    Knight,
    Brook
}
public abstract class PuzzleItemObject : ScriptableObject
{
    public int Id;
    public Sprite uiDisplay;
    public ItemType type;
    public int pos;
    [TextArea(15,20)]
    public string description;
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public Item(PuzzleItemObject item)
    {
        Name = item.name;
        Id = item.Id;
    }
}