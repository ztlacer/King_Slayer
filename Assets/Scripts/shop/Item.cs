using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public item itemStruct;
    
    void start()
    {
        if (gameObject.name == "armor") {
        makeItemStruct(30, "armor");
        }
    }

    void makeItemStruct(int cost, string name)
    {
        item newItem;
        newItem.cost = cost;
        newItem.name = name;
        itemStruct = newItem;
    }

    public struct item
    {
        public int cost;
        public string name;
    }
    void update()
    {
        print("hi");
        print(itemStruct.name);
    }
}
