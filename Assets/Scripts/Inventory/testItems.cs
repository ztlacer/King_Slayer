using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testItems : MonoBehaviour
{

    public InventoryObject inventory;
    public ItemObject obj;
    // Start is called before the first frame update
    void Start()
    {
        inventory.AddItem(obj, 1);
        inventory.AddItem(obj, 1);
        inventory.AddItem(obj, 1);
        inventory.AddItem(obj, 1);
        inventory.AddItem(obj, 1);
        inventory.AddItem(obj, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
