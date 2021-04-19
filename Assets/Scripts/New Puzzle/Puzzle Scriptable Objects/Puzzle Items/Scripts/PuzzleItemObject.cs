using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PuzzleItemType
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
    public PuzzleItemType type;
    public int pos;
    [TextArea(15,20)]
    public string description;
}

[System.Serializable]
public class PuzzleItem
{
    public string Name;
    public int Id;
    public PuzzleItem(PuzzleItemObject item)
    {
        Name = item.name;
        Id = item.Id;
    }
}