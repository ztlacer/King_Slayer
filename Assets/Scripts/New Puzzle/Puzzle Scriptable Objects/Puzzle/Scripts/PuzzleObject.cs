using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Puzzle", menuName = "Puzzle System/Puzzle")]
public class PuzzleObject : ScriptableObject
{
    public string savePath;
    public PuzzleItemDatabaseObject database;
    public Puzzle Container;

    public PuzzleObject()
    {

    }

    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, Container);
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Container = (Puzzle)formatter.Deserialize(stream);
            stream.Close();
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        Container = new Puzzle();
    }

}

[System.Serializable]
public class Puzzle
{
    public PuzzleSlot[] Items = new PuzzleSlot[16];
}

[System.Serializable]
public class PuzzleSlot
{
    public PuzzleItem item;
    public int ID;

    public PuzzleSlot(PuzzleItem _item, int _id)
    {
        item = _item;
        ID = _id;
    }

}
