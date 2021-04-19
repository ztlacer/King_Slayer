using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Puzzle Item Database", menuName = "Puzzle System/Items/Database")]
public class PuzzleItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public PuzzleItemObject[] Items;
    public Dictionary<int, PuzzleItemObject> GetItem = new Dictionary<int, PuzzleItemObject>();

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].Id = i;
            GetItem.Add(i, Items[i]);
            
        }
    }

    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, PuzzleItemObject>();
    }
}
